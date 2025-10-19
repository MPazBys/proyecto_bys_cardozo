using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_ReporteAdmin
    {
        public DataTable UltimoBackup()
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT TOP 1 fecha_backup, usuario_backup FROM backups ORDER BY fecha_backup DESC", cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable BackupsDelMes()
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT COUNT(*) AS TotalBackups
                      FROM backups
                      WHERE MONTH(fecha_backup) = MONTH(GETDATE()) 
                      AND YEAR(fecha_backup) = YEAR(GETDATE())", cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable UsuariosActivosInactivos()
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT 
                        CASE WHEN estado = 1 THEN 'Activos' ELSE 'Inactivos' END AS Estado,
                        COUNT(*) AS Cantidad
                      FROM usuario
                      GROUP BY estado", cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable UsuariosPorRol()
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT r.nombre_rol AS Rol, COUNT(*) AS Cantidad
                      FROM usuario u
                      INNER JOIN rol r ON u.id_rol = r.id_rol
                      GROUP BY r.nombre_rol", cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
