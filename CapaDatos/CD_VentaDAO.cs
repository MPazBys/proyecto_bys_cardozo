using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_VentaDAO
    {
        #region Conversión a XML

        private string ConvertirDetallesAVentaXML(List<Detalle_venta> detalles)
        {
            StringBuilder xml = new StringBuilder();
            xml.AppendLine("<Detalle>");
            foreach (var item in detalles)
            {
                xml.AppendLine("<Item>");
                xml.AppendLine($"<id_libro>{item.oLibro.id_libro}</id_libro>");
                xml.AppendLine($"<cantidad>{item.cantidad}</cantidad>");
                // Usamos "R" (Round-trip format specifier) para asegurar el formato decimal
                xml.AppendLine($"<precio_unitario>{item.precio_unitario.ToString(System.Globalization.CultureInfo.InvariantCulture)}</precio_unitario>");
                xml.AppendLine($"<descuento_aplicado>{item.descuento_aplicado.ToString(System.Globalization.CultureInfo.InvariantCulture)}</descuento_aplicado>");
                xml.AppendLine("</Item>");
            }
            xml.AppendLine("</Detalle>");
            return xml.ToString();
        }

        private string ConvertirPagosAPagosXML(List<Pagos> pagos)
        {
            StringBuilder xml = new StringBuilder();
            xml.AppendLine("<Pagos>");
            foreach (var pago in pagos)
            {
                xml.AppendLine("<Item>");
                xml.AppendLine($"<id_medio_de_pago>{pago.oMedio_De_Pago.id_medio_de_pago}</id_medio_de_pago>");
                xml.AppendLine($"<monto>{pago.monto.ToString(System.Globalization.CultureInfo.InvariantCulture)}</monto>");
                xml.AppendLine("</Item>");
            }
            xml.AppendLine("</Pagos>");
            return xml.ToString();
        }

        private string ConvertirPromocionesAplicadasXML(List<VentaPromocion> promociones)
        {
            StringBuilder xml = new StringBuilder();
            xml.AppendLine("<Promociones>");
            foreach (var promo in promociones)
            {
                xml.AppendLine("<Item>");
                xml.AppendLine($"<id_promocion>{promo.IdPromocion}</id_promocion>");
                xml.AppendLine($"<monto_descuento>{promo.MontoDescuento.ToString(System.Globalization.CultureInfo.InvariantCulture)}</monto_descuento>");
                xml.AppendLine("</Item>");
            }
            xml.AppendLine("</Promociones>");
            return xml.ToString();
        }

        #endregion

        // ==========================
        // REGISTRAR VENTA
        // ==========================
        public int Registrar(Venta objVenta, out string Mensaje)
        {
            int idGenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarVenta", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros de la Venta
                    cmd.Parameters.AddWithValue("@IdCliente", objVenta.oCliente.id_cliente);
                    cmd.Parameters.AddWithValue("@IdUsuario", objVenta.oUsuario.id_usuario);
                    cmd.Parameters.AddWithValue("@Fecha", objVenta.fecha);
                    cmd.Parameters.AddWithValue("@SubTotal", objVenta.subtotal);
                    cmd.Parameters.AddWithValue("@DescuentoTotal", objVenta.descuento_total);
                    cmd.Parameters.AddWithValue("@Total", objVenta.total);

                    // Parámetros XML
                    cmd.Parameters.AddWithValue("@DetalleVenta", ConvertirDetallesAVentaXML(objVenta.oDetalleVenta));
                    cmd.Parameters.AddWithValue("@PagosXML", ConvertirPagosAPagosXML(objVenta.oPagos));
                    cmd.Parameters.AddWithValue("@PromocionesXML", ConvertirPromocionesAplicadasXML(objVenta.oPromocionesAplicadas));

                    // Parámetros de salida
                    cmd.Parameters.Add("@IdVentaGenerado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@MensajeError", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;

                    con.Open();
                    cmd.ExecuteNonQuery();

                    idGenerado = Convert.ToInt32(cmd.Parameters["@IdVentaGenerado"].Value);
                    Mensaje = cmd.Parameters["@MensajeError"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idGenerado = 0;
                Mensaje = $"Error al registrar la venta en DB: {ex.Message}";
            }

            return idGenerado;
        }

        // ==========================
        // ANULAR VENTA
        // ==========================
        public bool AnularVenta(int idVenta, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_AnularVenta", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdVenta", idVenta);

                    // Parámetros de salida
                    cmd.Parameters.Add("@Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@MensajeError", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;

                    con.Open();
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["@Resultado"].Value);
                    Mensaje = cmd.Parameters["@MensajeError"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Mensaje = $"Error al anular la venta en DB: {ex.Message}";
            }

            return resultado;
        }
    }
}