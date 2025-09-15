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
    public class CD_Usuario
    {
        public List <Usuario> Listar ()
        {
            List<Usuario> lista = new List<Usuario>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "select id_usuario, dni, nombre, apellido, email, contrasena, estado from usuario";

                    SqlCommand cmd = new SqlCommand(query, oConexion);

                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuario()
                            { 
                                 id_usuario = Convert.ToInt32(dr["id_usuario"]),
                                 dni = dr["dni"].ToString(),
                                 nombre = dr["nombre"].ToString(),
                                 apellido = dr["apellido"].ToString(),
                                 email = dr["email"].ToString(),
                                 contrasena = dr["contrasena"].ToString(),
                                 estado = Convert.ToBoolean(dr["estado"])
                            });
                               
                        }
                    }

                }
                catch (Exception ex)
                {
                    lista = new List<Usuario>();

                }
            }

            return lista;
        }
    }
}
