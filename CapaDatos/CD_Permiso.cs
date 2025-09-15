using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Permiso
    {
        public List<Permiso> Listar(int idUsuario)
        {
            List<Permiso> lista = new List<Permiso>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select p.id_rol, p.nombre_menu from permiso p");
                    query.AppendLine("inner join rol r on r.id_rol = p.id_rol");
                    query.AppendLine("inner join usuario u on u.id_rol = r.id_rol");
                    query.AppendLine("where u.id_usuario = @id_usuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);

                    cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Permiso()
                            {
                                oRol = new Rol() {ID_rol = Convert.ToInt32(dr["id_rol"]) },
                                nombre_menu = dr["nombre_menu"].ToString()
                            });

                        }
                    }

                }
                catch (Exception ex)
                {
                    lista = new List<Permiso>();

                }
            }

            return lista;
        }
    }
}
