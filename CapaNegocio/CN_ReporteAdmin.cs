using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_ReporteAdmin
    {
        private CD_ReporteAdmin datos = new CD_ReporteAdmin();
        public DataTable ObtenerUltimoBackup() => datos.UltimoBackup();
        public DataTable ObtenerBackupsDelMes() => datos.BackupsDelMes();
        public DataTable ObtenerUsuariosActivosInactivos() => datos.UsuariosActivosInactivos();
        public DataTable ObtenerUsuariosPorRol() => datos.UsuariosPorRol();
    }
}
