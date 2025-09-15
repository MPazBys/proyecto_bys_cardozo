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
            List<Usuario> TEST = new CN_Usuario().Listar();

            Usuario oUsuario = new CN_Usuario().Listar().Where(u => u.dni == textDocumento.Text && u.contrasena == textContrasenia.Text).FirstOrDefault();

            if(oUsuario != null)
            {

                Inicio form = new Inicio(oUsuario);

                form.Show();
                this.Hide();

                form.FormClosing += frm_closing;

            }else
            {
                MessageBox.Show("no se encontro el usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void frm_closing (object sender, FormClosingEventArgs e )
        {

            textDocumento.Text += "";
            textContrasenia.Text += ""; 

            this.Show();
        }
    }
}
