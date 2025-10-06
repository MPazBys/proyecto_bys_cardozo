using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
// Referencias para Excel (ClosedXML)
using ClosedXML.Excel;
// Referencias para PDF (iTextSharp)
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace CapaPresentacion
{
    public partial class frmReporteAdmin : Form
    {
        public frmReporteAdmin()
        {
            InitializeComponent();
        }

        private void frmReporteAdmin_Load(object sender, EventArgs e)
        {
            // Cargar datos en dgvdata y configurar cbobusqueda al inicio, similar a frmUsuarios

            // Lógica para cargar las columnas de búsqueda en cbobusqueda
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                // Solo añadir columnas visibles y que no sean el botón de selección (si existiera)
                if (columna.Visible == true)
                {
                    // Asumiendo que tienes una clase OpcionCombo similar a la de frmUsuarios
                    // En este formulario solo se necesita el nombre de la columna (Name) y el texto de la cabecera (HeaderText)
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }

            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

            // Mostrar todos los usuarios al cargar el formulario de reporte
            CargarUsuariosEnDataGridView();
        }

        private void CargarUsuariosEnDataGridView()
        {
            // Limpia las filas existentes
            dgvdata.Rows.Clear();

            // Muestra todos los usuarios (usa la misma lógica de CN_Usuario().Listar())
            List<Usuario> listaUsuario = new CN_Usuario().Listar();

            foreach (Usuario item in listaUsuario)
            {
                // Asegúrate de que los nombres de las columnas en el dgvdata coincidan
                // con las cabeceras definidas en la imagen/descripción.
                dgvdata.Rows.Add(new object[] {
                    item.dni, // Columna Documento
                    item.nombre, // Columna Nombre
                    item.apellido, // Columna Apellido
                    item.email, // Columna Correo
                    item.usuario, // Columna Usuario
                    item.contrasena, // Columna Contrasena (OJO: generalmente no se muestra)
                    item.oRol.nombre_rol, // Columna Rol
                    item.estado == true ? 1 : 0, //Columna EstadoValor 
                    item.estado == true ? "Activo" : "No activo", // Columna Estado
                    item.sexo, // Columna Sexo
                    item.fecha_nacimiento.ToString("dd/MM/yyyy") // Columna FechaNacimiento
                });
            }
        }


        // --- Generación de Reporte Excel (ClosedXML) ---
        private void btnexcel_Click(object sender, EventArgs e)
        {
            // Crear un DataTable con los datos visibles del DataGridView
            DataTable dt = new DataTable();

            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible && columna.HeaderText != "")
                {
                    dt.Columns.Add(columna.HeaderText, typeof(string));
                }
            }

            // Llenar el DataTable con filas visibles
            foreach (DataGridViewRow fila in dgvdata.Rows)
            {
                if (fila.Visible)
                {
                    List<string> rowData = new List<string>();
                    foreach (DataGridViewColumn columna in dgvdata.Columns)
                    {
                        if (columna.Visible && columna.HeaderText != "")
                        {
                            rowData.Add(fila.Cells[columna.Name].Value?.ToString() ?? string.Empty);
                        }
                    }
                    dt.Rows.Add(rowData.ToArray());
                }
            }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos visibles para generar el reporte.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cuadro para guardar el archivo
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = $"ReporteUsuarios_{DateTime.Now:ddMMyyyy_HHmmss}.xlsx";
            saveFile.Filter = "Archivos Excel (*.xlsx)|*.xlsx";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var hoja = wb.Worksheets.Add(dt, "Usuarios");

                        // --- Formato de cabecera ---
                        var rangoCabecera = hoja.RangeUsed().FirstRow();
                        rangoCabecera.Style.Font.Bold = true;
                        rangoCabecera.Style.Fill.BackgroundColor = XLColor.FromHtml("#2E86C1"); // Azul
                        rangoCabecera.Style.Font.FontColor = XLColor.White;
                        rangoCabecera.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // --- Bordes y tamaño ---
                        hoja.Columns().AdjustToContents();
                        hoja.RangeUsed().Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        hoja.RangeUsed().Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                        wb.SaveAs(saveFile.FileName);
                        MessageBox.Show("Reporte Excel generado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al generar el Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        // --- Generación de Reporte PDF (iTextSharp) ---
        private void btnpdf_Click(object sender, EventArgs e)
        {
            // Verificar si hay filas visibles
            if (dgvdata.Rows.Cast<DataGridViewRow>().Count(r => r.Visible) < 1)
            {
                MessageBox.Show("No hay datos visibles para generar el reporte PDF.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = $"ReporteUsuarios_{DateTime.Now:ddMMyyyy_HHmmss}.pdf";
            saveFile.Filter = "Archivos PDF (*.pdf)|*.pdf";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Configuración del documento PDF
                    Document pdfDoc = new Document(PageSize.A4.Rotate(), 25, 25, 30, 30);
                    FileStream fs = new FileStream(saveFile.FileName, FileMode.Create, FileAccess.Write);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, fs);

                    pdfDoc.Open();

                    // Fuentes
                    var titleFont = FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD, BaseColor.BLUE);
                    var headerFont = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
                    var bodyFont = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                    // Título
                    Paragraph title = new Paragraph("LISTA DE USUARIOS", titleFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    };
                    pdfDoc.Add(title);
                    pdfDoc.Add(new Paragraph(" ")); // Espacio

                    // Crear tabla con columnas visibles
                    int numColumns = dgvdata.Columns.Cast<DataGridViewColumn>().Count(c => c.Visible && c.HeaderText != "");
                    PdfPTable pdfTable = new PdfPTable(numColumns)
                    {
                        WidthPercentage = 100
                    };

                    // Cabeceras
                    foreach (DataGridViewColumn col in dgvdata.Columns)
                    {
                        if (col.Visible && col.HeaderText != "")
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(col.HeaderText, headerFont))
                            {
                                BackgroundColor = new BaseColor(46, 134, 193),
                                HorizontalAlignment = Element.ALIGN_CENTER,
                                VerticalAlignment = Element.ALIGN_MIDDLE,
                                MinimumHeight = 20f
                            };
                            pdfTable.AddCell(cell);
                        }
                    }

                    // Datos
                    foreach (DataGridViewRow row in dgvdata.Rows)
                    {
                        if (row.Visible)
                        {
                            foreach (DataGridViewColumn col in dgvdata.Columns)
                            {
                                if (col.Visible && col.HeaderText != "")
                                {
                                    PdfPCell cell = new PdfPCell(new Phrase(row.Cells[col.Name].Value?.ToString() ?? "", bodyFont))
                                    {
                                        HorizontalAlignment = Element.ALIGN_CENTER,
                                        VerticalAlignment = Element.ALIGN_MIDDLE,
                                        MinimumHeight = 18f
                                    };
                                    pdfTable.AddCell(cell);
                                }
                            }
                        }
                    }

                    pdfDoc.Add(pdfTable);
                    pdfDoc.Close();
                    writer.Close();
                    fs.Close();

                    MessageBox.Show("Reporte PDF generado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al generar el PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // --- Lógica de Búsqueda y Limpieza (tomada de frmUsuarios) ---

        // Se asume que las implementaciones de btnbuscar_Click y btnlimpiarbuscador_Click 
        // son idénticas a las de frmUsuarios para manejar el filtrado del dgvdata.

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            // Lógica de búsqueda idéntica a la de frmUsuarios para filtrar las filas visibles en dgvdata
            // ... (copiar el código de la función btnbuscar_Click de frmUsuarios)
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();
            string textoBusqueda = txtbusqueda.Text.Trim().ToUpper();

            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (columnaFiltro == "Estado")
                    {
                        // Si el usuario busca "activo", verifica si el valor del estado es 1
                        if (textoBusqueda == "ACTIVO")
                        {
                            row.Visible = Convert.ToInt32(row.Cells["EstadoValor"].Value) == 1;
                        }
                        // Si el usuario busca "no activo" o "no", verifica si el valor del estado es 0
                        else if (textoBusqueda == "NO ACTIVO" || textoBusqueda == "NO")
                        {
                            row.Visible = Convert.ToInt32(row.Cells["EstadoValor"].Value) == 0;
                        }
                        else
                        {
                            // Si el texto no es "activo" ni "no activo", oculta la fila
                            row.Visible = false;
                        }

                    }
                    else
                    {
                        if (row.Cells[columnaFiltro].Value != null)
                        {
                            row.Visible = row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(textoBusqueda);
                        }
                        else
                        {
                            row.Visible = false;
                        }
                    }
                }
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            // Lógica de limpieza idéntica a la de frmUsuarios para mostrar todas las filas
            // ... (copiar el código de la función btnlimpiarbuscador_Click de frmUsuarios)
            txtbusqueda.Text = "";

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }
        }
    }
}

