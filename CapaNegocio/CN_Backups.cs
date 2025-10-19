using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Backups
    {
        private CD_Backups datosBackup = new CD_Backups();

        public bool RegistrarBackup(string usuario)
        {
            Backups backup = new Backups
            {
                UsuarioBackup = usuario
            };
            return datosBackup.RegistrarBackup(backup);
        }
    }
}
