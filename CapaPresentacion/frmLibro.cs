using CapaEntidad;
using CapaNegocio;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmLibro : Form
    {
        private string rutaImagenes = string.Empty;
        private int filaSeleccionada = -1; 
        private int idLibroSeleccionado = 0; 

        public frmLibro()
        {
            rutaImagenes = Path.Combine(Application.StartupPath, "ImagenesLibros");

            InitializeComponent();

            // Si la carpeta no existe, la creamos
            if (!Directory.Exists(rutaImagenes))
            {
                Directory.CreateDirectory(rutaImagenes);
            }

        }

        private void frmLibro_Load(object sender, EventArgs e)
        {
            picImagen.SizeMode = PictureBoxSizeMode.Zoom;

            // Configurar estado inicial de botones
            LimpiarCampos();
            ActualizarEstadoBotones(true);

            // Cargar ComboBox de Autor y Categoria
            CargarComboBoxAutores();
            CargarComboBoxCategorias();

            // Configurar ComboBox de Búsqueda
            CargarComboBoxBusqueda();

            // Cargar el DataGridView con los libros
            CargarGrillaLibros();
        }

        // --- MÉTODOS DE CARGA ---

        private void CargarComboBoxAutores()
        {
            CN_Libros cnLibro = new CN_Libros();
            List<Autor> autores = cnLibro.ListarAutores();

            cmbAutor.DataSource = autores;
            cmbAutor.DisplayMember = "nombre_autor";
            cmbAutor.ValueMember = "id_autor";
            cmbAutor.SelectedIndex = -1; // Sin selección
        }

        private void CargarComboBoxCategorias()
        {
            CN_Libros cnLibro = new CN_Libros();
            List<Categoria> categorias = cnLibro.ListarCategorias();

            cmbCategoria.DataSource = categorias;
            cmbCategoria.DisplayMember = "nombre_categoria";
            cmbCategoria.ValueMember = "id_categoria";
            cmbCategoria.SelectedIndex = -1; // Sin selección
        }

        private void CargarComboBoxBusqueda()
        {
            // Llenamos el ComboBox de búsqueda con las columnas visibles del DataGridView
            foreach (DataGridViewColumn columna in dgvLibros.Columns)
            {
                if (columna.Visible && columna.Name != "imagen" && columna.Name != "Estado")
                {
                    cmbBusqueda.Items.Add(columna.HeaderText);
                }
            }
            cmbBusqueda.SelectedIndex = 0;
        }

        private void CargarGrillaLibros()
        {
            CN_Libros cnLibro = new CN_Libros();
            List<Libros> listaLibros = cnLibro.Listar();

            dgvLibros.Rows.Clear(); // Limpiamos la grilla

            foreach (Libros libro in listaLibros)
            {
                dgvLibros.Rows.Add(new object[] {
                    "",
                    libro.id_libro,
                    libro.titulo,
                    libro.oAutor.nombre_autor,
                    libro.descripcion,
                    libro.oCategoria.nombre_categoria,
                    libro.precio_libro,
                    libro.stock_libro,
                    libro.imagen, // Nombre del archivo de imagen
                    libro.Estado ? "Activo" : "Inactivo"
                });
            }
        }

        // --- MANEJO DE IMAGEN ---

        private void btnExaminarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                // Mostramos el nombre del archivo en el TextBox
                txtImagen.Text = Path.GetFileName(openFile.FileName);

                // Guardamos la ruta completa temporalmente en el Tag del TextBox
                txtImagen.Tag = openFile.FileName;

                // Mostramos la imagen en el PictureBox
                picImagen.Image = Image.FromFile(openFile.FileName);
            }
        }

        // --- BOTONES CRUD ---

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Libros objLibro = new Libros();

            try
            {
                // 1. Validar y copiar imagen
                string nombreImagen = GuardarImagen(out mensaje);
                if (nombreImagen == null)
                {
                    MessageBox.Show(mensaje, "Error de Imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2. Poblar objeto Libro
                objLibro.titulo = txtTitulo.Text;
                objLibro.oAutor = new Autor() { id_autor = (int)cmbAutor.SelectedValue };
                objLibro.oCategoria = new Categoria() { id_categoria = (int)cmbCategoria.SelectedValue };
                objLibro.descripcion = txtDescripcion.Text;
                objLibro.precio_libro = Convert.ToDecimal(txtPrecio.Text);
                objLibro.stock_libro = Convert.ToInt32(txtStock.Text);
                objLibro.imagen = nombreImagen;
                objLibro.Estado = true; // Siempre activo al crear

                // 3. Llamar a CapaNegocio
                CN_Libros cnLibro = new CN_Libros();
                int idGenerado = cnLibro.Insertar(objLibro, out mensaje);

                if (idGenerado != 0)
                {
                    MessageBox.Show("Libro registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrillaLibros();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show($"Error al registrar el libro:\n{mensaje}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Libros objLibro = new Libros();

            string imagenAntigua = string.Empty;
            if (filaSeleccionada >= 0) // Usamos la variable que corregimos antes
            {
                imagenAntigua = dgvLibros.Rows[filaSeleccionada].Cells["imagen"].Value.ToString();
            }

            try
            {
                // 1. Validar y copiar imagen (si se cambió)
                string nombreImagen = GuardarImagen(out mensaje);
                if (nombreImagen == null)
                {
                    MessageBox.Show(mensaje, "Error de Imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2. Poblar objeto Libro
                objLibro.id_libro = idLibroSeleccionado; // Obtenido al seleccionar la fila
                objLibro.titulo = txtTitulo.Text;
                objLibro.oAutor = new Autor() { id_autor = (int)cmbAutor.SelectedValue };
                objLibro.oCategoria = new Categoria() { id_categoria = (int)cmbCategoria.SelectedValue };
                objLibro.descripcion = txtDescripcion.Text;
                objLibro.precio_libro = Convert.ToDecimal(txtPrecio.Text);
                objLibro.stock_libro = Convert.ToInt32(txtStock.Text);
                objLibro.imagen = nombreImagen;
                objLibro.Estado = chkActivo.Checked;


                // 3. Llamar a CapaNegocio
                CN_Libros cnLibro = new CN_Libros();
                bool resultado = cnLibro.Editar(objLibro, out mensaje);

                if (resultado)
                {
                    if (nombreImagen != imagenAntigua && !string.IsNullOrEmpty(imagenAntigua))
                    {
                        try
                        {
                            string rutaCompletaAntigua = Path.Combine(rutaImagenes, imagenAntigua);
                            if (File.Exists(rutaCompletaAntigua))
                            {
                                File.Delete(rutaCompletaAntigua);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al borrar imagen antigua: " + ex.Message);
                        }
                    }

                    MessageBox.Show("Libro modificado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrillaLibros();
                    LimpiarCampos();
                    ActualizarEstadoBotones(true);
                }
                else
                {
                    MessageBox.Show($"Error al modificar el libro:\n{mensaje}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            LimpiarCampos();

        }

        // --- INTERACCIÓN CON LA GRILLA (DataGridView) ---

        // Dibuja el ícono de selección (check) en la primera columna
        private void dgvLibros_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Ignorar encabezados
            if (e.RowIndex < 0)
                return;

            // Asegurarse de que la columna 0 es la del botón (check)
            if (e.ColumnIndex == 0 && dgvLibros.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                // Dibuja el ícono centrado
                int w = Properties.Resources.check.Width;
                int h = Properties.Resources.check.Height;
                int x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.check, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvLibros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            if (dgvLibros.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;

               
                if (indice >= 0) {

                    filaSeleccionada = indice;

                    idLibroSeleccionado = Convert.ToInt32(dgvLibros.Rows[indice].Cells["id_libro"].Value);

                    // Llenamos los campos del formulario
                    txtindice.Text = indice.ToString();
                    txtTitulo.Text = dgvLibros.Rows[indice].Cells["titulo"].Value.ToString();
                    cmbAutor.Text = dgvLibros.Rows[indice].Cells["id_autor"].Value.ToString();
                    txtDescripcion.Text = dgvLibros.Rows[indice].Cells["descripcion"].Value.ToString();
                    cmbCategoria.Text = dgvLibros.Rows[indice].Cells["id_categoria"].Value.ToString();
                    txtPrecio.Text = dgvLibros.Rows[indice].Cells["precio_libro"].Value.ToString();
                    txtStock.Text = dgvLibros.Rows[indice].Cells["stock_libro"].Value.ToString();
                    txtImagen.Text = dgvLibros.Rows[indice].Cells["imagen"].Value.ToString();
                    txtImagen.Tag = null;
                    chkActivo.Checked = dgvLibros.Rows[indice].Cells["Estado"].Value.ToString() == "Activo";

                    // Carga la imagen
                    string rutaCompletaImagen = Path.Combine(rutaImagenes, txtImagen.Text ?? "");
                    if (File.Exists(rutaCompletaImagen))
                        picImagen.Image = Image.FromFile(rutaCompletaImagen);
                    else
                        picImagen.Image = null;
                }
                // Actualiza estado de botones
                ActualizarEstadoBotones(false);
                
                
            }
        }


        // --- BÚSQUEDA Y LIMPIEZA ---

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = cmbBusqueda.SelectedItem.ToString();
            string textoBusqueda = txtBusqueda.Text.Trim().ToUpper();

            if (dgvLibros.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvLibros.Rows)
                {
                    // Buscamos el nombre de la columna que coincida con el texto del ComboBox
                    string nombreColumna = dgvLibros.Columns.Cast<DataGridViewColumn>()
                                         .FirstOrDefault(c => c.HeaderText == columnaFiltro)?.Name;

                    if (string.IsNullOrEmpty(nombreColumna)) continue;

                    string valorCelda = row.Cells[nombreColumna].Value?.ToString().Trim().ToUpper() ?? "";

                    if (valorCelda.Contains(textoBusqueda))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            foreach (DataGridViewRow row in dgvLibros.Rows)
            {
                row.Visible = true;
            }
        }

        // --- MÉTODOS AUXILIARES ---

        private void LimpiarCampos()
        {
            idLibroSeleccionado = 0;
            filaSeleccionada = -1;

            txtTitulo.Text = "";
            cmbAutor.SelectedIndex = -1;
            txtDescripcion.Text = "";
            cmbCategoria.SelectedIndex = -1;
            txtPrecio.Text = "";
            txtStock.Text = "";
            txtImagen.Text = "";
            txtImagen.Tag = null;
            picImagen.Image = null;
        }

        private void ActualizarEstadoBotones(bool estadoGuardar)
        {
            btnGuardar.Enabled = estadoGuardar;
            btnEditar.Enabled = !estadoGuardar;
            btnLimpiar.Enabled = !estadoGuardar;
        }

        private string GuardarImagen(out string mensaje)
        {
            mensaje = string.Empty;
            string nombreImagen = txtImagen.Text; // Nombre de imagen actual o nuevo

            // Escenario 1: El usuario seleccionó una imagen nueva
            if (txtImagen.Tag != null)
            {
                string rutaOriginal = txtImagen.Tag.ToString();
                string nuevoNombreImagen = Guid.NewGuid().ToString() + Path.GetExtension(rutaOriginal);
                string rutaDestino = Path.Combine(rutaImagenes, nuevoNombreImagen);

                try
                {
                    File.Copy(rutaOriginal, rutaDestino);
                    nombreImagen = nuevoNombreImagen; // Actualizamos al nuevo nombre
                }
                catch (Exception ex)
                {
                    mensaje = "Error al copiar la imagen: " + ex.Message;
                    return null;
                }
            }
            

            return nombreImagen;
        }

        private void txtTitulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsLetter(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&  
                e.KeyChar != ' ' &&
                e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void cmbAutor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void cmbCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                return;
            }
         
            string separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            if (e.KeyChar.ToString() == separator)
            {
                if (txtPrecio.Text.Contains(separator))
                {
                    e.Handled = true; 
                }
                else
                {
                    e.Handled = false; 
                }
                return;
            }

            e.Handled = true;
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            if (txtStock.Text.Length == 0 && e.KeyChar == '0')
            {
                e.Handled = true;
            }
        }

    }
}
