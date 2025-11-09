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
            // 1. Validaciones (Stock y Cliente)
            if (oVenta.oCliente == null || oVenta.oCliente.id_cliente == 0)
            {
                Mensaje = "Debe seleccionar un cliente para registrar la venta.";
                return 0;
            }

            foreach (var detalle in oVenta.oDetalleVenta)
            {
                // La carga real del stock la harías con CN_Libro.ObtenerStock(idLibro)
                if (detalle.oLibro.stock_libro < detalle.cantidad)
                {
                    Mensaje = $"Stock insuficiente para el libro: {detalle.oLibro.titulo}";
                    return 0;
                }
            }

            // 2. Ejecutar la lógica central de cálculo
            AplicarPromocionesYCalcularTotales(oVenta);

            // 3. Validación de Pagos (El total pagado debe cubrir el total neto a pagar)
            decimal sumaPagos = oVenta.oPagos.Sum(p => p.monto);
            if (sumaPagos < oVenta.total)
            {
                Mensaje = $"El monto pagado ({sumaPagos:C}) es menor al Total a Pagar ({oVenta.total:C}).";
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

            oVenta.subtotal = 0;
            oVenta.descuento_total = 0;
            oVenta.oPromocionesAplicadas = new List<VentaPromocion>();

            // 1. CÁLCULO DE DESCUENTOS POR ÍTEM
            foreach (var detalle in oVenta.oDetalleVenta)
            {
                detalle.precio_unitario = detalle.oLibro.precio_libro;
                detalle.subtotal_linea = detalle.precio_unitario * detalle.cantidad;
                detalle.descuento_aplicado = 0; // Se acumulará el descuento solo de ÍTEMS

                // Buscar la mejor promoción de ÍTEM (Regla: SOLO aplica la de mayor valor entre libro, categoría, autor)
                Promocion mejorPromoItem = null;

                // 1. Por Libro
                var promoLibro = promosItem.FirstOrDefault(p => p.Tipo == "libro" && p.IdItemAsociado == detalle.oLibro.id_libro);

                // 2. Por Categoría
                // ASUMIMOS: oLibro.oCategoria tiene el ID de la categoría del libro
                var promoCategoria = promosItem.FirstOrDefault(p => p.Tipo == "categoria" && detalle.oLibro.oCategoria.id_categoria == p.IdItemAsociado);

                // 3. Por Autor
                // ASUMIMOS: oLibro.oAutor tiene el ID del autor del libro
                var promoAutor = promosItem.FirstOrDefault(p => p.Tipo == "autor" && detalle.oLibro.oAutor.id_autor == p.IdItemAsociado);


                // Encontrar la que tiene el mayor descuento (podrías querer que solo aplique una)
                // Usaremos una simple jerarquía: Libro > Categoría > Autor
                if (promoLibro != null) mejorPromoItem = promoLibro;
                else if (promoCategoria != null) mejorPromoItem = promoCategoria;
                else if (promoAutor != null) mejorPromoItem = promoAutor;


                if (mejorPromoItem != null)
                {
                    // Cálculo del descuento: (Precio * Cantidad) * (% Descuento / 100)
                    decimal descuentoMonto = detalle.subtotal_linea * mejorPromoItem.ValorDescuento / 100M;
                    detalle.descuento_aplicado = descuentoMonto;
                    oVenta.descuento_total += descuentoMonto;

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

            // 2. CÁLCULO DE DESCUENTOS POR MEDIO DE PAGO
            decimal descuentoMedioPagoTotal = 0;

            foreach (var pago in oVenta.oPagos)
            {
                Promocion promoMedioPago = promosMedioPago.FirstOrDefault(p => p.Tipo == "medio_pago" && p.IdItemAsociado == pago.oMedio_De_Pago.id_medio_de_pago);

                if (promoMedioPago != null)
                {
                    // El descuento se aplica sobre el MONTO pagado con ese medio
                    decimal descuentoMonto = pago.monto * promoMedioPago.ValorDescuento / 100M;
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

            // 3. CONSOLIDAR TOTALES
            oVenta.descuento_total += descuentoMedioPagoTotal;
            oVenta.total = oVenta.subtotal - oVenta.descuento_total;
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

