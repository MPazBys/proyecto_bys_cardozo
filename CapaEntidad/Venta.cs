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
        public Cliente oCliente { get; set; } // Asumo que existe esta entidad
        public Usuario oUsuario { get; set; } // Asumo que existe esta entidad
        public decimal subtotal { get; set; } // Nuevo: Suma de (precio_unitario * cantidad)
        public decimal descuento_total { get; set; } // Nuevo: Descuentos de Ítems + Descuentos de Pagos
        public decimal total { get; set; } // Total Neto a Pagar (subtotal - descuento_total)
        public string fecha { get; set; }
        public bool estado { get; set; } = true; // 1: Activa, 0: Anulada

        // Colecciones para enviar/recibir datos complejos al/del SP
        public List<Detalle_venta> oDetalleVenta { get; set; }
        public List<Pagos> oPagos { get; set; } // Cambiado de Pagos a Pago por convención
        public List<VentaPromocion> oPromocionesAplicadas { get; set; }
    }
}
