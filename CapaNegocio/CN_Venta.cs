using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Venta
    {
        private CD_VentaDAO oCDVenta = new CD_VentaDAO();
        private CN_Promocion oCNPromocion = new CN_Promocion();
        // Asume la existencia de CN_Libro, CN_Categoria, CN_Autor, etc.
        // Asumo que oLibro dentro de Detalle_venta ya tiene su Categoria y Autor cargados. 

        public int RegistrarVenta(Venta oVenta, out string Mensaje)
        {
            // 1. Validaciones de Stock
            if (oVenta.oCliente == null || oVenta.oCliente.id_cliente == 0)
            {
                Mensaje = "Debe seleccionar un cliente para registrar la venta.";
                return 0;
            }

            foreach (var detalle in oVenta.oDetalleVenta)
            {
                if (detalle.oLibro.stock_libro < detalle.cantidad)
                {
                    Mensaje = $"Stock insuficiente para el libro: {detalle.oLibro.titulo}";
                    return 0;
                }
            }

            // 2. EJECUTAR LA LÓGICA CENTRAL DE CÁLCULO EN EL SERVIDOR
            // Esto asegura que los totales sean validados de manera consistente.
            AplicarPromocionesYCalcularTotales(oVenta);

            // 3. Validación de Pagos (El total pagado debe cubrir el total neto a pagar)
            decimal sumaPagos = oVenta.oPagos.Sum(p => p.monto);
            // Redondeo obligatorio para evitar errores de precisión decimal
            decimal sumaPagosRedondeada = Math.Round(sumaPagos, 2);

            if (sumaPagosRedondeada < oVenta.total)
            {
                // Este mensaje de error AHORA usará el total correcto: 19.099,50
                Mensaje = $"El monto pagado ({sumaPagosRedondeada:C}) es menor al Total a Pagar ({oVenta.total:C}).";
                return 0;
            }

            // 4. Registrar en Capa Datos
            return oCDVenta.Registrar(oVenta, out Mensaje);
        }


        // ====================================================================
        // LÓGICA CLAVE: APLICACIÓN DE PROMOCIONES SEGÚN REGLAS
        // ====================================================================
        private void AplicarPromocionesYCalcularTotales(Venta oVenta)
        {
            // Obtener promociones activas y vigentes
            List<Promocion> promosActivas = oCNPromocion.Listar()
                .Where(p => p.Estado && p.FechaInicio.Date <= DateTime.Now.Date && p.FechaFin.Date >= DateTime.Now.Date).ToList();

            // Separar promociones por tipo
            var promosItem = promosActivas.Where(p => p.Tipo == "libro" || p.Tipo == "categoria" || p.Tipo == "autor").ToList();
            var promosMedioPago = promosActivas.Where(p => p.Tipo == "medio_pago").ToList();
            //  Incluir la promoción 'general'
            var promosGeneral = promosActivas.Where(p => p.Tipo == "general").ToList();

            oVenta.subtotal = 0;
            oVenta.descuento_total = 0;
            oVenta.oPromocionesAplicadas = new List<VentaPromocion>();

            // 1. CÁLCULO DE DESCUENTOS POR ÍTEM
            foreach (var detalle in oVenta.oDetalleVenta)
            {
                // Recalcular Subtotal Línea
                detalle.precio_unitario = detalle.oLibro.precio_libro;
                detalle.subtotal_linea = detalle.precio_unitario * detalle.cantidad;
                detalle.descuento_aplicado = 0;

                Promocion mejorPromoItem = null;

                // Lógica de búsqueda (Asumimos que oLibro ya tiene oAutor y oCategoria cargados)
                var promoLibro = promosItem.FirstOrDefault(p => p.Tipo == "libro" && p.IdItemAsociado == detalle.oLibro.id_libro);
                var promoCategoria = (detalle.oLibro != null && detalle.oLibro.oCategoria != null) ? promosItem.FirstOrDefault(p => p.Tipo == "categoria" && detalle.oLibro.oCategoria.id_categoria == p.IdItemAsociado) : null;
                var promoAutor = (detalle.oLibro != null && detalle.oLibro.oAutor != null) ? promosItem.FirstOrDefault(p => p.Tipo == "autor" && detalle.oLibro.oAutor.id_autor == p.IdItemAsociado) : null;

                // Jerarquía: Libro > Categoría > Autor
                if (promoLibro != null) mejorPromoItem = promoLibro;
                else if (promoCategoria != null) mejorPromoItem = promoCategoria;
                else if (promoAutor != null) mejorPromoItem = promoAutor;

                if (mejorPromoItem != null)
                {
                    decimal descuentoMonto = detalle.subtotal_linea * mejorPromoItem.ValorDescuento / 100M;
                    detalle.descuento_aplicado = Math.Round(descuentoMonto, 2); // Redondear descuento por ítem
                    oVenta.descuento_total += detalle.descuento_aplicado;

                    // Registrar la promoción aplicada (usamos Linq para evitar duplicados si la promo ya existe)
                    if (oVenta.oPromocionesAplicadas.All(p => p.IdPromocion != mejorPromoItem.IdPromocion))
                    {
                        oVenta.oPromocionesAplicadas.Add(new VentaPromocion
                        {
                            IdPromocion = mejorPromoItem.IdPromocion,
                            MontoDescuento = (decimal)descuentoMonto,
                            NombrePromocion = mejorPromoItem.Nombre,
                            TipoPromocion = mejorPromoItem.Tipo
                        });
                    }
                    else
                    {
                        // Si la promoción ya fue registrada (ej. por otro libro en la misma categoría), se actualiza el monto.
                        oVenta.oPromocionesAplicadas.First(p => p.IdPromocion == mejorPromoItem.IdPromocion).MontoDescuento += (decimal)descuentoMonto;
                    }
                }
                oVenta.subtotal += detalle.subtotal_linea;
            }

            // Calcular subtotal neto después de descuentos por ítem
            decimal descuentoTotalItem = oVenta.oDetalleVenta.Sum(d => d.descuento_aplicado);
            decimal subtotalNetoItem = oVenta.subtotal - descuentoTotalItem;

            // 2. CÁLCULO DE DESCUENTO GENERAL
            Promocion promoGeneral = promosGeneral.FirstOrDefault();
            if (promoGeneral != null)
            {
                decimal montoDescuentoGeneral = subtotalNetoItem * promoGeneral.ValorDescuento / 100M;
                montoDescuentoGeneral = Math.Round(montoDescuentoGeneral, 2); // Redondear el descuento general
                oVenta.descuento_total += montoDescuentoGeneral;

                // 🔑 Lógica de registro VentaPromocion para General
                if (oVenta.oPromocionesAplicadas.All(p => p.IdPromocion != promoGeneral.IdPromocion))
                {
                    oVenta.oPromocionesAplicadas.Add(new VentaPromocion
                    {
                        IdPromocion = promoGeneral.IdPromocion,
                        MontoDescuento = montoDescuentoGeneral,
                        NombrePromocion = promoGeneral.Nombre,
                        TipoPromocion = promoGeneral.Tipo
                    });
                }
                else
                {
                    // Si por alguna razón la promo ya existía, suma el monto (aunque no debería pasar con 'general')
                    oVenta.oPromocionesAplicadas.First(p => p.IdPromocion == promoGeneral.IdPromocion).MontoDescuento += montoDescuentoGeneral;
                }
            }

            // 3. CÁLCULO DE DESCUENTOS POR MEDIO DE PAGO
            decimal descuentoMedioPagoTotal = 0;
            foreach (var pago in oVenta.oPagos)
            {
                Promocion promoMedioPago = promosMedioPago.FirstOrDefault(p => p.Tipo == "medio_pago" && p.IdItemAsociado == pago.oMedio_De_Pago.id_medio_de_pago);

                if (promoMedioPago != null)
                {
                    decimal descuentoMonto = pago.monto * promoMedioPago.ValorDescuento / 100M;
                    descuentoMonto = Math.Round(descuentoMonto, 2); // Redondear el descuento por pago
                    pago.descuento_medio_pago = descuentoMonto;
                    descuentoMedioPagoTotal += descuentoMonto;

                    // Registrar promoción aplicada
                    oVenta.oPromocionesAplicadas.Add(new VentaPromocion
                    {
                        IdPromocion = promoMedioPago.IdPromocion,
                        MontoDescuento = (decimal)descuentoMonto,
                        NombrePromocion = promoMedioPago.Nombre,
                        TipoPromocion = promoMedioPago.Tipo
                    });
                }
            }

            // 4. CONSOLIDAR Y REDONDEAR TOTAL FINAL
            oVenta.descuento_total = Math.Round(oVenta.descuento_total + descuentoMedioPagoTotal, 2);
            oVenta.total = oVenta.subtotal - oVenta.descuento_total;
            oVenta.total = Math.Round(oVenta.total, 2); // REDONDEO CRÍTICO FINAL
        }

        public bool AnularVenta(int idVenta, out string Mensaje)
        {
            return oCDVenta.AnularVenta(idVenta, out Mensaje);
        }

        public DataSet ObtenerVentaCompleta(int idVenta)
        {
            return oCDVenta.ObtenerVentaCompleta(idVenta);
        }

        public int ReporteTotalAnuladas(DateTime fechaInicio, DateTime fechaFin)
        {
            return oCDVenta.ReporteTotalAnuladas(fechaInicio, fechaFin);
        }
    }
}

