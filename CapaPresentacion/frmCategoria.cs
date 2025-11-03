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

namespace CapaPresentacion
{
    public partial class frmCategoria : Form
    {

        private CN_Categoria objCN_Categoria = new CN_Categoria();
        private Categoria categoriaSeleccionada;
        private int indiceSeleccionado = -1;

        public frmCategoria()
        {
            InitializeComponent();


            CargarCategorias();
        }

        private void CargarCategorias()
        {
            dgvCategorias.Rows.Clear();

            List<Categoria> lista = objCN_Categoria.Listar();

            foreach (Categoria item in lista)
            {
                dgvCategorias.Rows.Add(null, item.id_categoria, item.nombre_categoria);
            }

            dgvCategorias.ClearSelection();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Categoria obj = new Categoria()
            {
                nombre_categoria = txtNombreCategoria.Text.Trim()
            };

            int idGenerado = objCN_Categoria.Registrar(obj, out mensaje);

            if (idGenerado != 0)
            {
                MessageBox.Show("Categoría registrada correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarCategorias();
                txtNombreCategoria.Clear();
            }
            else
            {
                MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (categoriaSeleccionada == null)
            {
                MessageBox.Show("Seleccione una categoría de la lista", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mensaje = string.Empty;

            categoriaSeleccionada.nombre_categoria = txtNombreCategoria.Text.Trim();

            bool resultado = objCN_Categoria.Editar(categoriaSeleccionada, out mensaje);

            if (resultado)
            {
                MessageBox.Show("Categoría actualizada correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarCategorias();
                txtNombreCategoria.Clear();
                categoriaSeleccionada = null;
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (categoriaSeleccionada == null)
            {
                MessageBox.Show("Seleccione una categoría para eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Desea eliminar la categoría seleccionada?", "Confirmación",
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                string mensaje = string.Empty;
                bool resultado = objCN_Categoria.Eliminar(categoriaSeleccionada, out mensaje);

                if (resultado)
                {
                    MessageBox.Show("Categoría eliminada correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarCategorias();
                    txtNombreCategoria.Clear();
                    categoriaSeleccionada = null;
                }
                else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                indiceSeleccionado = e.RowIndex;
                int idCategoria = Convert.ToInt32(dgvCategorias.Rows[e.RowIndex].Cells["id_categoria"].Value);
                string nombre = dgvCategorias.Rows[e.RowIndex].Cells["nombre_categoria"].Value.ToString();

                categoriaSeleccionada = new Categoria()
                {
                    id_categoria = idCategoria,
                    nombre_categoria = nombre
                };

                txtNombreCategoria.Text = nombre;
            }
        }

    }
}
