using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Usuario
    {
        private CD_Usuario objcd_usuario = new CD_Usuario();

        public List<Usuario> Listar()
        {
            return objcd_usuario.Listar();
        }

        public int registrar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.dni == "")
            {
                Mensaje += "Es necesario el documento del usuario\n";
            }

            if (obj.nombre == "") {
                Mensaje += "Es necesario el nombre del usuario\n";
            }

            if (obj.apellido == "")
            {
                Mensaje += "Es necesario el apellido del usuario\n";
            }

            if (obj.email == "")
            {
                Mensaje += "Es necesario el correo del usuario\n";
            }

            if (obj.contrasena == "")
            {
                Mensaje += "Es necesario la contraseña del usuario\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_usuario.registrar(obj, out Mensaje);
            }
        }

        public bool editar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.dni == "")
            {
                Mensaje += "Es necesario el documento del usuario\n";
            }

            if (obj.nombre == "")
            {
                Mensaje += "Es necesario el nombre del usuario\n";
            }

            if (obj.apellido == "")
            {
                Mensaje += "Es necesario el apellido del usuario\n";
            }

            if (obj.email == "")
            {
                Mensaje += "Es necesario el correo del usuario\n";
            }

            if (obj.contrasena == "")
            {
                Mensaje += "Es necesario la contraseña del usuario\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_usuario.editar(obj, out Mensaje);
            }
        }

        public bool activar(Usuario obj, out string Mensaje)
        {
            return objcd_usuario.activar(obj, out Mensaje);
        }

        public bool desactivar(Usuario obj, out string Mensaje)
        {
            return objcd_usuario.desactivar(obj, out Mensaje);
        }

        public DataTable ReporteVendedores(DateTime fechaInicio, DateTime fechaFin)
        {
            return objcd_usuario.ReporteVendedores(fechaInicio, fechaFin);
        }
    }
}
