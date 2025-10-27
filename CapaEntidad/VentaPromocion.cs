using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class VentaPromocion
    {
        public int IdVenta { get; set; }
        public int IdPromocion { get; set; }
        public decimal MontoDescuento { get; set; }

        // Propiedades opcionales
        public string NombrePromocion { get; set; }
        public DateTime FechaVenta { get; set; }
    }
}
