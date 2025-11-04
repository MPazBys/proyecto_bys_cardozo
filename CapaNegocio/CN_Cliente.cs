using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Cliente
    {
        private CD_Cliente objcd_cliente = new CD_Cliente();

        public List<Cliente> Listar()
        {
            return objcd_cliente.Listar();
        }

        public int registrar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.dni == 0)
            {
                Mensaje += "Es necesario el cuit del cliente\n";
            }

            if (obj.nombre == "")
            {
                Mensaje += "Es necesario el nombre del cliente\n";
            }

            if (obj.email == "")
            {
                Mensaje += "Es necesario el correo del cliente\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_cliente.registrar(obj, out Mensaje);
            }
        }

        public bool editar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.dni == 0)
            {
                Mensaje += "Es necesario el cuit del cliente\n";
            }

            if (obj.nombre == "")
            {
                Mensaje += "Es necesario el nombre del cliente\n";
            }

            if (obj.email == "")
            {
                Mensaje += "Es necesario el correo del cliente\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_cliente.editar(obj, out Mensaje);
            }
        }

        public bool activar(Cliente obj, out string Mensaje)
        {
            return objcd_cliente.activar(obj, out Mensaje);
        }

        public bool desactivar(Cliente obj, out string Mensaje)
        {
            return objcd_cliente.desactivar(obj, out Mensaje);
        }

        public Cliente ObtenerClientePorDNI(long dni)
        {
            return objcd_cliente.ObtenerPorDNI(dni);
        }
    }
}