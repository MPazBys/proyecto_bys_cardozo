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
using System.Globalization;

namespace CapaNegocio
{
    public class CN_FacturaPDF
    {
        public string GenerarFacturaPDF(Venta venta, int idVenta)
        {
            CultureInfo culture = new CultureInfo("es-AR");

            try
            {
                SaveFileDialog guardarDialogo = new SaveFileDialog();
                guardarDialogo.Title = "Guardar Factura";
                guardarDialogo.FileName = $"Factura_{idVenta}.pdf";
                guardarDialogo.Filter = "Archivos PDF (*.pdf)|*.pdf";

                if (guardarDialogo.ShowDialog() != DialogResult.OK)
                    return "CANCELADO";

                string rutaArchivo = guardarDialogo.FileName;

                // COLORES Y FUENTES
                BaseColor colorAzul = new BaseColor(24, 69, 114);
                Font fTitulo = new Font(Font.FontFamily.HELVETICA, 16, Font.BOLD, BaseColor.WHITE);
                Font fNormal = new Font(Font.FontFamily.HELVETICA, 9, Font.NORMAL);
                Font fSubTitulo = new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD);
                Font fEncabezado = new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD, BaseColor.WHITE);
                Font fTotalFinal = new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD, colorAzul);
                Font fResumen = new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD);

                Document doc = new Document(PageSize.A4, 30, 30, 40, 40);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));
                doc.Open();

                // ====================== BARRA AZUL GRANDE SUPERIOR ======================
                PdfPTable barraTop1 = new PdfPTable(1) { WidthPercentage = 100 };
                PdfPCell cTop1 = new PdfPCell(new Phrase("LIBROS M&P", fTitulo));
                cTop1.Border = Rectangle.NO_BORDER;
                cTop1.BackgroundColor = colorAzul;
                cTop1.HorizontalAlignment = Element.ALIGN_RIGHT;
                cTop1.PaddingTop = 18f;
                cTop1.PaddingBottom = 18f;
                cTop1.PaddingRight = 20f;
                barraTop1.AddCell(cTop1);
                doc.Add(barraTop1);

                // Línea blanca
                PdfPTable lineaBlancaTop = new PdfPTable(1) { WidthPercentage = 100 };
                PdfPCell cWhiteTop = new PdfPCell() { BackgroundColor = BaseColor.WHITE, Border = Rectangle.NO_BORDER, FixedHeight = 6f };
                lineaBlancaTop.AddCell(cWhiteTop);
                doc.Add(lineaBlancaTop);

                // Barra azul chica
                PdfPTable barraTop2 = new PdfPTable(1) { WidthPercentage = 100 };
                PdfPCell cTop2 = new PdfPCell() { BackgroundColor = colorAzul, Border = Rectangle.NO_BORDER, FixedHeight = 12f };
                barraTop2.AddCell(cTop2);
                doc.Add(barraTop2);

                // TÍTULO FACTURA
                Paragraph tituloFactura = new Paragraph($"FACTURA DE VENTA N° {idVenta}", new Font(Font.FontFamily.HELVETICA, 16, Font.BOLD, colorAzul));
                tituloFactura.Alignment = Element.ALIGN_CENTER;
                tituloFactura.SpacingBefore = 18f;
                tituloFactura.SpacingAfter = 20f;
                doc.Add(tituloFactura);

                // ================= DATOS CLIENTE / VENDEDOR =================
                PdfPTable infoTable = new PdfPTable(2);
                infoTable.WidthPercentage = 100;
                infoTable.SetWidths(new float[] { 1f, 1f });
                infoTable.SpacingAfter = 20f;

                PdfPCell clientCell = new PdfPCell() { Border = Rectangle.NO_BORDER };
                clientCell.AddElement(new Phrase("DATOS DEL CLIENTE", fSubTitulo));
                clientCell.AddElement(new Phrase($"Nombre: {venta.oCliente.nombre} {venta.oCliente.apellido}", fNormal));
                clientCell.AddElement(new Phrase($"CUIT: {venta.oCliente.dni}", fNormal));
                clientCell.AddElement(new Phrase($"Fecha Venta: {venta.fecha}", fNormal));

                PdfPCell companyCell = new PdfPCell() { Border = Rectangle.NO_BORDER };
                companyCell.AddElement(new Phrase("DATOS DEL VENDEDOR", fSubTitulo));
                companyCell.AddElement(new Phrase($"Vendedor: {venta.oUsuario.nombre}", fNormal));
                companyCell.AddElement(new Phrase("Sucursal: Central", fNormal));
                companyCell.AddElement(new Phrase($"Tipo Doc: {venta.tipo_doc}", fNormal));

                infoTable.AddCell(clientCell);
                infoTable.AddCell(companyCell);
                doc.Add(infoTable);

                // ================= DETALLE =================
                PdfPTable tablaDetalle = new PdfPTable(5);
                tablaDetalle.WidthPercentage = 100;
                tablaDetalle.SetWidths(new float[] { 4f, 2f, 1.5f, 2f, 2.5f });
                tablaDetalle.SpacingAfter = 20f;

                string[] headers = { "Libro", "Precio Unitario", "Cantidad", "Descuento Item", "Sub Total Neto" };
                foreach (var h in headers)
                {
                    PdfPCell headerCell = new PdfPCell(new Phrase(h, fEncabezado));
                    headerCell.BackgroundColor = colorAzul;
                    headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    headerCell.Padding = 5f;
                    tablaDetalle.AddCell(headerCell);
                }

                foreach (var item in venta.oDetalleVenta)
                {
                    decimal subtotalNeto = item.subtotal_linea - item.descuento_aplicado;
                    tablaDetalle.AddCell(new Phrase(item.oLibro.titulo, fNormal));
                    tablaDetalle.AddCell(new PdfPCell(new Phrase(item.precio_unitario.ToString("C", culture), fNormal)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                    tablaDetalle.AddCell(new PdfPCell(new Phrase(item.cantidad.ToString(), fNormal)) { HorizontalAlignment = Element.ALIGN_CENTER });
                    tablaDetalle.AddCell(new PdfPCell(new Phrase(item.descuento_aplicado.ToString("C", culture), fNormal)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                    tablaDetalle.AddCell(new PdfPCell(new Phrase(subtotalNeto.ToString("C", culture), fNormal)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                }
                doc.Add(tablaDetalle);

                // ================= PROMOS + TOTALES =================
                PdfPTable summaryTable = new PdfPTable(2);
                summaryTable.WidthPercentage = 100;
                summaryTable.SetWidths(new float[] { 5.5f, 4.5f });

                PdfPCell promoCell = new PdfPCell() { Border = Rectangle.NO_BORDER };
                promoCell.AddElement(new Phrase("PROMOCIONES APLICADAS:", fSubTitulo));

                if (venta.oPromocionesAplicadas != null && venta.oPromocionesAplicadas.Count > 0)
                    foreach (var promo in venta.oPromocionesAplicadas)
                        promoCell.AddElement(new Phrase($"{promo.NombrePromocion}: -{promo.MontoDescuento.ToString("C", culture)}", fNormal));
                else
                    promoCell.AddElement(new Phrase("No se aplicaron promociones adicionales.", fNormal));

                PdfPTable totalsTable = new PdfPTable(2);
                totalsTable.WidthPercentage = 100;
                totalsTable.DefaultCell.Border = Rectangle.NO_BORDER;

                totalsTable.AddCell(new Phrase("SUBTOTAL:", fResumen));
                totalsTable.AddCell(new Phrase(venta.subtotal.ToString("C", culture), fNormal));

                totalsTable.AddCell(new Phrase("DESCUENTOS TOTALES:", fResumen));
                totalsTable.AddCell(new Phrase($"-{venta.descuento_total.ToString("C", culture)}", fNormal));

                totalsTable.AddCell(new Phrase("TOTAL NETO:", fTotalFinal));
                totalsTable.AddCell(new Phrase(venta.total.ToString("C", culture), fTotalFinal));

                decimal totalPagado = venta.oPagos.Sum(p => p.monto);
                decimal vuelto = totalPagado - venta.total;

                totalsTable.AddCell(new Phrase("Monto Pagado:", fNormal));
                totalsTable.AddCell(new Phrase(totalPagado.ToString("C", culture), fNormal));

                totalsTable.AddCell(new Phrase("Vuelto:", fResumen));
                totalsTable.AddCell(new Phrase(vuelto.ToString("C", culture), fResumen));

                summaryTable.AddCell(promoCell);
                summaryTable.AddCell(new PdfPCell(totalsTable) { Border = Rectangle.NO_BORDER });

                doc.Add(summaryTable);

                //FACTURA ANULADA
                if(venta.estado == false){
                    Paragraph facturaAnulada = new Paragraph($"VENTA ANULADA", new Font(Font.FontFamily.HELVETICA, 16, Font.BOLD, colorAzul));
                    facturaAnulada.Alignment = Element.ALIGN_CENTER;
                    facturaAnulada.SpacingBefore = 18f;
                    facturaAnulada.SpacingAfter = 20f;
                    doc.Add(facturaAnulada);
                }

                // ====================== PIE PEGADO AL FINAL ======================
                PdfContentByte cb = writer.DirectContent;

                // Barra azul grande inferior
                cb.SetColorFill(colorAzul);
                cb.Rectangle(0, 0, doc.PageSize.Width, 36f);
                cb.Fill();

                // Línea blanca
                cb.SetColorFill(BaseColor.WHITE);
                cb.Rectangle(0, 36f, doc.PageSize.Width, 6f);
                cb.Fill();

                // Barra azul chica
                cb.SetColorFill(colorAzul);
                cb.Rectangle(0, 42f, doc.PageSize.Width, 14f);
                cb.Fill();

                doc.Close();
                return rutaArchivo;
            }
            catch (Exception ex)
            {
                return $"ERROR: {ex.Message}";
            }
        }

    }
}