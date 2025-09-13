using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Venta
    {
        public int id_venta { get; set; }
        public Cliente oCliente { get; set; }
        public Usuario oUsuario { get; set; }
        public float total { get; set; }
        public string fecha { get; set; }
    }
}
