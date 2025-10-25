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

        public float monto { get; set; }

        public string fecha_pago { get; set; }
    }
}
