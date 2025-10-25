using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Promocion
    {
        public int IdPromocion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }              // producto, categoria, medio_pago, cantidad, general
        public decimal ValorDescuento { get; set; }   // Porcentaje o monto fijo
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Estado { get; set; }              // true = activa, false = inactiva

    }
}
