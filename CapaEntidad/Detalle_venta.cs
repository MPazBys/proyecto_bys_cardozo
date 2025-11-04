using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Detalle_venta
    {
        public int id_detalle { get; set; }
        public Venta oVenta { get; set; }
        public Libros oLibro { get; set; } // Asumo que tienes una entidad 'Libro'
        public int cantidad { get; set; }
        public decimal precio_unitario { get; set; } // Precio del libro al momento de la venta
        public decimal descuento_aplicado { get; set; } // Monto del descuento por promoción de ítem
        public decimal subtotal_linea { get; set; } // Usado en CN: (precio_unitario * cantidad)
    }
}
