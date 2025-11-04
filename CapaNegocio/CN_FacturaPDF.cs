using CapaEntidad;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class CN_FacturaPDF
    {
        public string GenerarFacturaPDF(Venta venta, int idVenta)
        {
            try
            {
                SaveFileDialog guardarDialogo = new SaveFileDialog();
                guardarDialogo.Title = "Guardar Factura";
                guardarDialogo.FileName = $"Factura_{idVenta}.pdf";
                guardarDialogo.Filter = "Archivos PDF (*.pdf)|*.pdf";

                if (guardarDialogo.ShowDialog() != DialogResult.OK)
                {
                    return "CANCELADO";
                }

                string rutaArchivo = guardarDialogo.FileName;

                Document doc = new Document(PageSize.A4, 20, 20, 20, 20);
                PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));
                doc.Open();

                Paragraph titulo = new Paragraph("Factura de Venta", new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD));
                titulo.Alignment = Element.ALIGN_CENTER;
                doc.Add(titulo);

                doc.Add(new Paragraph($"Fecha: {venta.fecha}"));
                doc.Add(new Paragraph($"Cliente: {venta.oCliente.nombre} {venta.oCliente.apellido}"));
                doc.Add(new Paragraph($"DNI: {venta.oCliente.dni}"));
                doc.Add(new Paragraph(" "));

                PdfPTable tabla = new PdfPTable(5);
                tabla.WidthPercentage = 100;
                tabla.AddCell("Libro");
                tabla.AddCell("Precio");
                tabla.AddCell("Cantidad");
                tabla.AddCell("Descuento");
                tabla.AddCell("Total");

                foreach (var item in venta.oDetalleVenta)
                {
                    tabla.AddCell(item.oLibro.titulo);
                    tabla.AddCell(item.precio_unitario.ToString("0.00"));
                    tabla.AddCell(item.cantidad.ToString());
                    tabla.AddCell(item.descuento_aplicado.ToString("0.00"));
                    tabla.AddCell((item.subtotal_linea - item.descuento_aplicado).ToString("0.00"));
                }

                doc.Add(tabla);
                doc.Add(new Paragraph(" "));

                if (venta.oPromocionesAplicadas != null && venta.oPromocionesAplicadas.Count > 0)
                {
                    doc.Add(new Paragraph("Promociones aplicadas:"));
                    foreach (var promo in venta.oPromocionesAplicadas)
                    {
                        doc.Add(new Paragraph($"• {promo.NombrePromocion}: -${promo.MontoDescuento:0.00}"));
                    }
                }

                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph($"Subtotal: ${venta.subtotal:0.00}"));
                doc.Add(new Paragraph($"Descuentos totales: -${venta.descuento_total:0.00}"));
                doc.Add(new Paragraph($"TOTAL: ${venta.total:0.00}", new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD)));

                doc.Close();

                return rutaArchivo;
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
    }
}