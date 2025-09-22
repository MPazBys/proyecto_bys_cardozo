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
    public class CD_Rol
    {
        public List<Rol> Listar()
        {
            List<Rol> lista = new List<Rol>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select id_rol, nombre_rol from rol");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);

                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Rol()
                            {
                                ID_rol = Convert.ToInt32(dr["id_rol"]),
                                nombre_rol = dr["nombre_rol"].ToString()
                            });

                        }
                    }

                }
                catch (Exception ex)
                {
                    lista = new List<Rol>();

                }
            }

            return lista;
        }
    }
}
