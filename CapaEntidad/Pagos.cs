using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Pagos
    {

        public int id_pago { get; set; }
        public Venta oVenta { get; set; }
        public Medio_de_pago oMedio_De_Pago { get; set; }
        public decimal monto { get; set; } // Monto pagado con este medio
        public string fecha_pago { get; set; }

        // Campo auxiliar en CN para guardar el descuento de medio de pago
        public decimal descuento_medio_pago { get; set; }
    }
}
