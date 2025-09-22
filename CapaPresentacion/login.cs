using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            ValidarCampos();

            List<Usuario> TEST = new CN_Usuario().Listar();

            Usuario oUsuario = new CN_Usuario().Listar().Where(u => u.dni == textDocumento.Text && u.contrasena == textContrasenia.Text).FirstOrDefault();

            if (oUsuario != null)
            {
                // Si el usuario existe, se procede a verificar su estado.
                // La propiedad 'estado' en tu clase `Usuario` debe ser un booleano (true para activo, false para no activo).
                if (oUsuario.estado)
                {
                    // El usuario es válido y está activo, se permite el ingreso.
                    Inicio form = new Inicio(oUsuario);

                    form.Show();
                    this.Hide();

                    form.FormClosing += frm_closing;
                }
                else
                {
                    // El usuario es válido, pero su estado es "no activo", se le niega el acceso.
                    MessageBox.Show("El usuario no se encuentra activo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
            {
                MessageBox.Show("no se encontro el usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }




        }

        private void frm_closing(object sender, FormClosingEventArgs e)
        {

            textDocumento.Clear();
            textContrasenia.Clear();

            this.Show();
        }

        private void TextDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // Verificar si ya hay 8 caracteres y el usuario quiere escribir otro
            if (!char.IsControl(e.KeyChar) && textDocumento.Text.Length >= 8)
            {
                MessageBox.Show("La longitud debe ser igual a ocho caracteres",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                e.Handled = true;
            }


        }

        private void ValidarCampos()
        {
            string errores = "";

            // Validar documento
            if (textDocumento.Text.Length != 8)
            {
                errores += "- El Número de Documento debe tener exactamente 8 caracteres.\n";
            }

            // Validar contraseña
            if (string.IsNullOrWhiteSpace(textContrasenia.Text))
            {
                errores += "- Debe ingresar la contraseña.\n";
            }

            // Mostrar mensaje si hay errores
            if (!string.IsNullOrEmpty(errores))
            {
                MessageBox.Show(errores, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


        }


    }
}

