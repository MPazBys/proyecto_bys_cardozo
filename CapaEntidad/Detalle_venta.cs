using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Detalle_venta
    {
        public Cliente oCliente { get; set; }
        public int cantidad { get; set; }
        public Venta oVenta { get; set; }
        public Libros oLibro { get; set; }
    }
}
