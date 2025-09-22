using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Usuario
    {
        public int id_usuario { get; set; }
        public string dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string contrasena { get; set; }
        public string usuario { get; set; }
        public Rol oRol { get; set; }
        public bool estado { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string sexo { get; set; }

    }
}
