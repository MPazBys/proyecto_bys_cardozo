using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
using System.Configuration;

namespace CapaDatos
{
    public class CD_Backups
    {
        public bool RegistrarBackup(Backups backup)
        {
            bool resultado = false;
            string connectionString = ConfigurationManager.ConnectionStrings["cadena_conexion"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Backups (usuario_backup) VALUES (@usuario)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@usuario", backup.UsuarioBackup);

                conn.Open();
                resultado = cmd.ExecuteNonQuery() > 0;
            }
            return resultado;
        }

    }
}
