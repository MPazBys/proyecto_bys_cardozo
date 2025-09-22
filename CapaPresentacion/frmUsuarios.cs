using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaPresentacion.Utilidades;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            List<Rol> listaRol = new CN_Rol().Listar();

            foreach (Rol item in listaRol) {
                cborol.Items.Add(new OpcionCombo() { Valor = item.ID_rol, Texto = item.nombre_rol });
            }

            cborol.DisplayMember = "Texto";
            cborol.ValueMember = "Valor";
            cborol.SelectedIndex = 0;


            foreach (DataGridViewColumn columna in dgvdata.Columns) {
                if (columna.Visible == true && columna.Name != "btnseleccionar") { 
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name , Texto = columna.HeaderText});
                }
            }

            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;


            //Mostrar todos los usuarios
            List<Usuario> listaUsuario = new CN_Usuario().Listar();

            foreach (Usuario item in listaUsuario)
            {
                dgvdata.Rows.Add(new object[] {"", item.id_usuario, item.dni, item.nombre,
                    item.apellido, item.email, item.usuario, item.contrasena,
                    item.oRol.ID_rol, 
                    item.oRol.nombre_rol,
                    item.estado == true ? 1 : 0,
                    item.estado == true ? "Activo" : "No activo",
                    item.sexo,
                    item.fecha_nacimiento
                });
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            string genero = "";
            if (rbmujer.Checked) genero = "FEMENINO";
            else if (rbhombre.Checked) genero = "MASCULINO";
            
            Usuario objusuario = new Usuario()
            {
                id_usuario = Convert.ToInt32(txtid.Text),
                oRol = new Rol() { ID_rol = Convert.ToInt32(((OpcionCombo)cborol.SelectedItem).Valor) },
                nombre = txtnombre.Text,
                apellido = txtapellido.Text,
                email = txtemail.Text,
                usuario = txtusuario.Text,
                contrasena = txtcontrasena.Text,
                dni = txtdni.Text,
                fecha_nacimiento = dtpFecha.Value,
                sexo = genero
            };


            if (string.IsNullOrEmpty(txtdni.Text) || string.IsNullOrEmpty(txtnombre.Text) ||
                        string.IsNullOrEmpty(txtapellido.Text) || string.IsNullOrEmpty(txtemail.Text) ||
                        string.IsNullOrEmpty(txtusuario.Text) || string.IsNullOrEmpty(txtcontrasena.Text) ||
                        string.IsNullOrEmpty(genero))
            {
                MessageBox.Show("Algún campo se encuentra incompleto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!txtemail.Text.Contains("@") || !txtemail.Text.Contains("."))
            {
                MessageBox.Show("El correo electronico no tiene un formato válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if(txtcontrasena.Text != txtconfcont.Text)
            {
                MessageBox.Show("Las contraseñas deben coincidir", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (objusuario.id_usuario == 0) {
                int idusuarioregistrado = new CN_Usuario().registrar(objusuario, out mensaje);

                if (idusuarioregistrado != 0)
                {
                    dgvdata.Rows.Add(new object[] {"", idusuarioregistrado, txtdni.Text, txtnombre.Text,
                    txtapellido.Text, txtemail.Text, txtusuario.Text, txtcontrasena.Text,
                    ((OpcionCombo)cborol.SelectedItem).Valor.ToString(),
                    ((OpcionCombo)cborol.SelectedItem).Texto.ToString(),
                    1, "Activo",
                    genero,
                    dtpFecha.Value.ToString("dd/MM/yyyy")
                });
               
                    limpiar();
                        

                }
                else
                {
                    MessageBox.Show(mensaje);
                }

            } else { 
                bool resultado = new CN_Usuario().editar(objusuario, out mensaje);

                if (resultado) {
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)];

                    row.Cells["Id"].Value = txtid.Text;
                    row.Cells["Documento"].Value = txtdni.Text;
                    row.Cells["Nombre"].Value = txtnombre.Text;
                    row.Cells["Apellido"].Value = txtapellido.Text;
                    row.Cells["Correo"].Value = txtemail.Text;
                    row.Cells["Usuario"].Value = txtusuario.Text;
                    row.Cells["contrasena"].Value = txtcontrasena.Text;
                    row.Cells["IdRol"].Value = ((OpcionCombo)cborol.SelectedItem).Valor.ToString();
                    row.Cells["Rol"].Value = ((OpcionCombo)cborol.SelectedItem).Texto.ToString();
                    row.Cells["Sexo"].Value = genero;
                    row.Cells["FechaNacimiento"].Value = dtpFecha.Value;

                    limpiar();
                } else
                {
                    MessageBox.Show(mensaje);
                }
            }

            
        }

        private void limpiar() {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtdni.Text = "";
            txtnombre.Text = "";
            txtapellido.Text = "";
            txtemail.Text = "";
            txtusuario.Text = "";
            txtcontrasena.Text = "";
            txtconfcont.Text = "";
            dtpFecha.Value = DateTime.Now;
            rbhombre.Checked = false;
            rbmujer.Checked = true;
            cborol.SelectedIndex = 0;

            txtdni.Select();
        }

        private void tgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0) {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.check.Width; 
                var h = Properties.Resources.check.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.check, new Rectangle(x,y,w,h));
                e.Handled = true;
            }
        }

        private void tgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvdata.Columns[e.ColumnIndex].Name == "btnseleccionar") {
                int indice = e.RowIndex;

                if (indice >= 0) {
                    txtindice.Text = indice.ToString();
                    txtid.Text = dgvdata.Rows[indice].Cells["Id"].Value.ToString();
                    txtdni.Text = dgvdata.Rows[indice].Cells["Documento"].Value.ToString();
                    txtnombre.Text = dgvdata.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtapellido.Text = dgvdata.Rows[indice].Cells["Apellido"].Value.ToString();
                    txtemail.Text = dgvdata.Rows[indice].Cells["Correo"].Value.ToString();
                    txtusuario.Text = dgvdata.Rows[indice].Cells["Usuario"].Value.ToString();
                    txtcontrasena.Text = dgvdata.Rows[indice].Cells["contrasena"].Value.ToString();
                    txtconfcont.Text = dgvdata.Rows[indice].Cells["contrasena"].Value.ToString();

                    DateTime fecha = Convert.ToDateTime(dgvdata.Rows[indice].Cells["FechaNacimiento"].Value);
                    dtpFecha.Value = fecha;

                    string sexo = dgvdata.Rows[indice].Cells["Sexo"].Value.ToString();
                    if(sexo.Equals("MASCULINO", StringComparison.OrdinalIgnoreCase)) {
                        rbhombre.Checked = true;
                        rbmujer.Checked = false;
                    } else if(sexo.Equals("FEMENINO", StringComparison.OrdinalIgnoreCase)) {
                        rbhombre.Checked = false;
                        rbmujer.Checked = true;
                    } else {
                        rbhombre.Checked = false;
                        rbmujer.Checked = false;
                    }

                    foreach (OpcionCombo oc in cborol.Items) {
                        if(Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["IdRol"].Value)) {
                            int indice_combo = cborol.Items.IndexOf(oc);
                            cborol.SelectedIndex = indice_combo;
                            break;
                        }
                    }

                   
                }
            }
        }

        private void btndesactivar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0) { 
                if(MessageBox.Show("¿Desea desactivar este usuario?", "Desactivar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;

                    Usuario objusuario = new Usuario()
                    {
                        id_usuario = Convert.ToInt32(txtid.Text)
                    };

                    bool respuesta = new CN_Usuario().desactivar(objusuario, out mensaje);

                    if (respuesta)
                    {
                        // Encuentra la fila correspondiente en el DataGridView
                        foreach (DataGridViewRow row in dgvdata.Rows)
                        {
                            // Busca la fila por el ID de usuario
                            if (row.Cells["id_usuario"].Value.ToString() == txtid.Text)
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
            if (Convert.ToInt32(txtid.Text) != 1)
            {
                if (MessageBox.Show("¿Desea activar este usuario?", "Activar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;

                    Usuario objusuario = new Usuario()
                    {
                        id_usuario = Convert.ToInt32(txtid.Text)
                    };

                    bool respuesta = new CN_Usuario().activar(objusuario, out mensaje);

                    if (respuesta)
                    {
                        // Encuentra la fila correspondiente en el DataGridView
                        foreach (DataGridViewRow row in dgvdata.Rows)
                        {
                            // Busca la fila por el ID de usuario
                            if (row.Cells["id_usuario"].Value.ToString() == txtid.Text)
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

        private void txtdni_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // Verificar si ya hay 8 caracteres y el usuario quiere escribir otro
            if (!char.IsControl(e.KeyChar) && txtdni.Text.Length >= 8)
            {
                MessageBox.Show("La longitud debe ser igual a ocho caracteres",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                e.Handled = true;
            }
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtnombre_Leave(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtnombre.Text))
            {
                txtnombre.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtnombre.Text.ToLower());

            }
        }

        private void txtapellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtapellido_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtapellido.Text))
            {
                txtapellido.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtapellido.Text.ToLower());

            }
        }
    }
}
