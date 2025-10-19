using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {

            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnseleccionar")
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }

            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;


            //Mostrar todos los usuarios
            List<Cliente> listaCliente = new CN_Cliente().Listar();

            String apeynom = "";

            foreach (Cliente item in listaCliente)
            {
                apeynom = item.nombre + " " + item.apellido;

                dgvdata.Rows.Add(new object[] {"", item.id_cliente, item.dni, apeynom,
                    item.email,
                    item.fecha_creacion.ToString("dd/MM/yyyy"),
                    item.estado == true ? 1 : 0,
                    item.estado == true ? "Activo" : "No activo"
                });
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            // 1. OBTENER Y PREPARAR EL NOMBRE COMPLETO
            string nombreCompleto = txtnombre.Text.Trim(); // .Trim() para quitar espacios al inicio/fin

            // 2. DIVIDIR EL NOMBRE COMPLETO EN PALABRAS
            string[] partesNombre = nombreCompleto.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string nombre;
            string apellido;

            // 3. ASIGNAR VALORES SEGÚN EL NÚMERO DE PALABRAS
            if (partesNombre.Length == 1)
            {
                // Si solo hay una palabra (ej: "Roberto" o "Microsoft")
                nombre = partesNombre[0];
                apellido = string.Empty; // Dejamos el apellido vacío o null
            }
            else if (partesNombre.Length > 1)
            {
                // Si hay varias palabras (ej: "Roberto Perez" o "Juan Carlos Lopez")

                // El apellido es SIEMPRE la última palabra
                apellido = partesNombre[partesNombre.Length - 1];

                // El nombre es TODO lo demás (desde la primera palabra hasta la penúltima)
                // Ejemplo: Si es "Juan Carlos Perez", toma "Juan Carlos"
                nombre = string.Join(" ", partesNombre, 0, partesNombre.Length - 1);
            }
            else
            {
                // Si está vacío
                nombre = string.Empty;
                apellido = string.Empty;
            }


            Cliente obj = new Cliente()
            {
                id_cliente = Convert.ToInt32(txtid.Text),
                nombre = nombre,
                apellido = apellido,
                email = txtemail.Text,
                dni = Convert.ToInt64(txtcuit.Text),
                estado = true
            };


            if (string.IsNullOrEmpty(txtcuit.Text) || string.IsNullOrEmpty(txtnombre.Text) ||
                        string.IsNullOrEmpty(txtemail.Text))
            {
                MessageBox.Show("Algún campo se encuentra incompleto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!txtemail.Text.Contains("@") || !txtemail.Text.Contains("."))
            {
                MessageBox.Show("El correo electronico no tiene un formato válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (obj.id_cliente == 0)
            {
                int idclienteregistrado = new CN_Cliente().registrar(obj, out mensaje);
                DateTime date = obj.fecha_creacion;
                string fecha = date.ToString("dd/MM/yyyy");

                if (idclienteregistrado != 0)
                {
                    dgvdata.Rows.Add(new object[] {"", idclienteregistrado, txtcuit.Text, txtnombre.Text,
                    txtemail.Text, fecha,
                    1, "Activo"
                });

                    limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }

            }
            else
            {
                bool resultado = new CN_Cliente().editar(obj, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)];

                    row.Cells["Id_Cliente"].Value = txtid.Text;
                    row.Cells["CUIT"].Value = txtcuit.Text;
                    row.Cells["NombreCompleto"].Value = txtnombre.Text;
                    row.Cells["Email"].Value = txtemail.Text;
                    limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
        }

        private void limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtcuit.Text = "";
            txtnombre.Text = "";
            txtemail.Text = "";

            txtcuit.Select();
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.check.Width;
                var h = Properties.Resources.check.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.check, new Rectangle(x, y, w, h));
                e.Handled = true;

            }
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtid.Text = dgvdata.Rows[indice].Cells["ID_Cliente"].Value.ToString();
                    txtcuit.Text = dgvdata.Rows[indice].Cells["CUIT"].Value.ToString();
                    txtnombre.Text = dgvdata.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtemail.Text = dgvdata.Rows[indice].Cells["Email"].Value.ToString();
                }
            }
        }

        private void btndesactivar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Desea desactivar este cliente?", "Desactivar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;

                    Cliente obj = new Cliente()
                    {
                        id_cliente = Convert.ToInt32(txtid.Text)
                    };

                    bool respuesta = new CN_Cliente().desactivar(obj, out mensaje);

                    if (respuesta)
                    {
                        // Encuentra la fila correspondiente en el DataGridView
                        foreach (DataGridViewRow row in dgvdata.Rows)
                        {
                            // Busca la fila por el ID de cliente
                            if (row.Cells["id_cliente"].Value.ToString() == txtid.Text)
                            {
                                // Actualiza el valor de la celda "EstadoValor" a 0
                                row.Cells["EstadoValor"].Value = 0;

                                // Actualiza el valor de la celda "Estado" a "No activo"
                                row.Cells["Estado"].Value = "No activo";
                                break; // Sale del bucle una vez que encuentra y actualica la fila
                            }
                        }

                        MessageBox.Show(mensaje, "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnactivar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Desea activar este cliente?", "Activar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;

                    Cliente obj = new Cliente()
                    {
                        id_cliente = Convert.ToInt32(txtid.Text)
                    };

                    bool respuesta = new CN_Cliente().activar(obj, out mensaje);

                    if (respuesta)
                    {
                        // Encuentra la fila correspondiente en el DataGridView
                        foreach (DataGridViewRow row in dgvdata.Rows)
                        {
                            // Busca la fila por el ID de cliente
                            if (row.Cells["id_cliente"].Value.ToString() == txtid.Text)
                            {
                                // Actualiza el valor de la celda "EstadoValor" a 1
                                row.Cells["EstadoValor"].Value = 1;

                                // Actualiza el valor de la celda "Estado" a "Activo"
                                row.Cells["Estado"].Value = "Activo";
                                break; // Sale del bucle una vez que encuentra y actualica la fila
                            }
                        }

                        MessageBox.Show(mensaje, "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            // Obtiene el nombre de la columna seleccionada para filtrar
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();
            // Obtiene el texto de búsqueda, lo limpia de espacios y lo convierte a mayúsculas para una búsqueda sin distinción entre mayúsculas y minúsculas
            string textoBusqueda = txtbusqueda.Text.Trim().ToUpper();

            // Verifica si hay filas en el DataGridView
            if (dgvdata.Rows.Count > 0)
            {
                // Itera sobre cada fila del DataGridView
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    // Manejo especial para la columna "Estado"
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
                    // Lógica de búsqueda normal para otras columnas
                    else
                    {
                        // Comprueba si el valor de la celda en la columna de filtro contiene el texto de búsqueda
                        if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(textoBusqueda))
                        {
                            // Si lo contiene, hace la fila visible
                            row.Visible = true;
                        }
                        else
                        {
                            // De lo contrario, oculta la fila
                            row.Visible = false;
                        }
                    }
                }
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtnombre_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtnombre.Text))
            {
                txtnombre.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtnombre.Text.ToLower());
            }
        }

        private void txtcuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // Verificar si ya hay 8 caracteres y el usuario quiere escribir otro
            if (!char.IsControl(e.KeyChar) && txtcuit.Text.Length >= 11)
            {
                MessageBox.Show("La longitud debe ser igual a once caracteres",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                e.Handled = true;
            }
        }
    }
}
