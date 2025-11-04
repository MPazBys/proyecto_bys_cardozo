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
        public decimal MontoDescuento { get; set; } // Usamos decimal para precisión monetaria

        // Propiedades de ayuda para la visualización en la UI
        public string NombrePromocion { get; set; }
        public string TipoPromocion { get; set; }
    }
}
