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
using FontAwesome.Sharp;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Inicio : Form
    {
        private static Usuario usuarioActual;
        private static IconMenuItem menuActivo = null;
        private static Form formularioActivo = null;

        public Inicio(Usuario objusuarios)
        {
            usuarioActual = objusuarios;

            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            List<Permiso> listaPermisos = new CN_Permiso().Listar(usuarioActual.id_usuario);

            foreach (IconMenuItem iconMenu in menu.Items) {

                //si el item es el de salir, no aplicamos el control de permisos
                if (iconMenu.Name == "menusalir")
                    continue;

                bool encontrado = listaPermisos.Any(m => m.nombre_menu == iconMenu.Name);

                if (encontrado == false)
                {
                    iconMenu.Visible = false;
                }
            }

            lblusuario.Text = usuarioActual.apellido + " " + usuarioActual.nombre;
        }

        private void abrirFormulario(IconMenuItem menu, Form formulario)
        {
            if(menuActivo != null)
            {
                menuActivo.BackColor = Color.White;
            }

            menu.BackColor = Color.Silver;
            menuActivo = menu;
            
            if(formularioActivo != null)
            {
                formularioActivo.Close();
            }

            //configuracion del menu
            formularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            //agregamos el form al contenedor
            contenedor.Controls.Add(formulario);

            //mostramos el form
            formulario.Show();
        }

        private void menuusuarios_Click(object sender, EventArgs e)
        {
            abrirFormulario((IconMenuItem)sender, new frmUsuarios());
        }

        private void menucategoria_Click(object sender, EventArgs e)
        {
            abrirFormulario(menuproductos, new frmCategoria());
        }

        private void menulibros_Click(object sender, EventArgs e)
        {
            abrirFormulario(menuproductos, new frmLibro());
        }

        private void menuregistrarventa_Click(object sender, EventArgs e)
        {
            abrirFormulario(menuventas, new frmAddVenta());
        }

        private void menuverdetalle_Click(object sender, EventArgs e)
        {
            abrirFormulario(menuventas, new frmDetalleVenta());
        }

        private void menuclientes_Click(object sender, EventArgs e)
        {
            abrirFormulario((IconMenuItem)sender, new frmCliente());
        }

        private void menureportes_Click(object sender, EventArgs e)
        {

            if (usuarioActual.oRol.nombre_rol == "VENDEDOR")
            {
                abrirFormulario((IconMenuItem)sender, new frmReporteVendedor());
            }
            else if (usuarioActual.oRol.nombre_rol == "ADMINISTRADOR")
            {
                abrirFormulario((IconMenuItem)sender, new frmReporteAdmin());
            }
            else if (usuarioActual.oRol.nombre_rol == "GERENTE")
            {
                abrirFormulario((IconMenuItem)sender, new frmReporteGerente());
            }
        }

        private void menubackup_Click(object sender, EventArgs e)
        {
            abrirFormulario((IconMenuItem)sender, new frmBackup(usuarioActual));
        }

        private void menusalir_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("¿Cerrar sesión y volver al inicio?",
                                "Cerrar sesión",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
        }

    }

        private void menupromociones_Click(object sender, EventArgs e)
        {
            abrirFormulario((IconMenuItem)sender, new frmPromociones());
        }
    }
}
