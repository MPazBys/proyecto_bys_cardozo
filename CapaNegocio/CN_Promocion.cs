using CapaEntidad;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Promocion
    {
        private CD_PromocionDAO dao = new CD_PromocionDAO();

        public List<Promocion> Listar()
        {
            return dao.Listar();
        }

        public bool Guardar(Promocion p)
        {
            if (p.IdPromocion == 0)
            {
                p.Estado = true;
                return dao.Insertar(p); // Llama al DAO
            }
            else
                return dao.Editar(p); // Llama al DAO
        }

        public bool Eliminar(int id)
        {
            return dao.Eliminar(id);
        }

        public bool CambiarEstado(int idPromocion, bool nuevoEstado)
        {
            return dao.CambiarEstado(idPromocion, nuevoEstado);
        }

        public List<Promocion> Buscar(string texto, bool? activa)
        {
            return dao.Filtrar(texto, activa);
        }

        public List<ItemDescuento> ObtenerItemsAsociados(string tipo)
        {
            return dao.ObtenerItemsAsociados(tipo);
        }
    }
}
