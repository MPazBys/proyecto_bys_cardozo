using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Backups
    {
        public int IdBackup { get; set; }
        public DateTime FechaBackup { get; set; }
        public string UsuarioBackup { get; set; }
    }
}
