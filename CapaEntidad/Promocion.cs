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
        public string Tipo { get; set; }
        public decimal ValorDescuento { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Estado { get; set; }

        // Campo para manejar el ID del elemento asociado (libro, cat, autor, etc.)
        public int IdItemAsociado { get; set; }

    }
}
