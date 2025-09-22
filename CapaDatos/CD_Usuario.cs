using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("select u.id_usuario, u.dni, u.nombre, u.apellido, u.email, u.contrasena, u.usuario, u.fecha_nacimiento, u.sexo, u.estado, r.id_rol, r.nombre_rol from usuario u");
                    query.AppendLine("inner join rol r on r.id_rol = u.id_rol");
 
                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);

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
                                 usuario = dr["usuario"].ToString(),
                                 estado = Convert.ToBoolean(dr["estado"]),
                                 oRol = new Rol() { ID_rol = Convert.ToInt32(dr["id_rol"]) , nombre_rol = dr["nombre_rol"].ToString() },
                                 fecha_nacimiento = Convert.ToDateTime(dr["fecha_nacimiento"]).Date,
                                 sexo = dr["sexo"].ToString() 
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


        public int registrar(Usuario obj, out string Mensaje) {
            int idusuariogenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena)) {

                    SqlCommand cmd = new SqlCommand("SP_RegistrarUsuario", oConexion);

                    cmd.Parameters.AddWithValue("id_rol", obj.oRol.ID_rol);
                    cmd.Parameters.AddWithValue("nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("apellido", obj.apellido);
                    cmd.Parameters.AddWithValue("email", obj.email);
                    cmd.Parameters.AddWithValue("contrasena", obj.contrasena);
                    cmd.Parameters.AddWithValue("usuario", obj.usuario);
                    cmd.Parameters.AddWithValue("dni", obj.dni);
                    cmd.Parameters.AddWithValue("fecha_nacimiento", obj.fecha_nacimiento);
                    cmd.Parameters.AddWithValue("sexo", obj.sexo);

                    cmd.Parameters.Add("idUsuarioResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    idusuariogenerado = Convert.ToInt32(cmd.Parameters["idUsuarioResultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex){
                idusuariogenerado = 0;
                Mensaje = ex.Message;
            }


            return idusuariogenerado;
        }

        public bool editar(Usuario obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("SP_EditarUsuario", oConexion);
                    
                    cmd.Parameters.AddWithValue("id_usuario", obj.id_usuario);
                    cmd.Parameters.AddWithValue("id_rol", obj.oRol.ID_rol);
                    cmd.Parameters.AddWithValue("nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("apellido", obj.apellido);
                    cmd.Parameters.AddWithValue("email", obj.email);
                    cmd.Parameters.AddWithValue("contrasena", obj.contrasena);
                    cmd.Parameters.AddWithValue("usuario", obj.usuario);
                    cmd.Parameters.AddWithValue("dni", obj.dni);
                    cmd.Parameters.AddWithValue("fecha_nacimiento", obj.fecha_nacimiento);
                    cmd.Parameters.AddWithValue("sexo", obj.sexo);

                    cmd.Parameters.Add("Respuesta", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }


            return respuesta;
        }

        public bool desactivar(Usuario obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("SP_DesactivarUsuario", oConexion);

                    cmd.Parameters.AddWithValue("id_usuario", obj.id_usuario);

                    cmd.Parameters.Add("Respuesta", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }


            return respuesta;
        }

        public bool activar(Usuario obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("SP_ActivarUsuario", oConexion);

                    cmd.Parameters.AddWithValue("id_usuario", obj.id_usuario);

                    cmd.Parameters.Add("Respuesta", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }


            return respuesta;
        }
    }
}
