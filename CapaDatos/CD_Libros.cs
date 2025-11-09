using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Configuration;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Libros
    {
        // Leemos la cadena de conexión del App.config
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["cadena_conexion"].ConnectionString;

        public List<Libros> Listar()
        {
            List<Libros> lista = new List<Libros>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ListarLibros", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Libros()
                            {
                                
                                id_libro = Convert.ToInt32(dr["id_libro"]),
                                titulo = dr["titulo"].ToString(),
                                oAutor = new Autor() { id_autor = Convert.ToInt32(dr["id_autor"]), nombre_autor = dr["nombre_autor"].ToString() },
                                oCategoria = new Categoria() { id_categoria = Convert.ToInt32(dr["id_categoria"]), nombre_categoria = dr["nombre_categoria"].ToString() },
                                descripcion = dr["descripcion"].ToString(),
                                precio_libro = Convert.ToDecimal(dr["precio_libro"]),
                                stock_libro = Convert.ToInt32(dr["stock_libro"]),
                                imagen = dr["imagen"].ToString(),
                                Estado = Convert.ToBoolean(dr["estado"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejar el error (por ejemplo, registrar en un log)
                    Console.WriteLine(ex.Message);
                    lista = new List<Libros>(); // Devuelve lista vacía en caso de error
                }
            }
            return lista;
        }

        public int Insertar(Libros obj, out string Mensaje)
        {
            int idLibroGenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertarLibro", con);
                    cmd.Parameters.AddWithValue("titulo", obj.titulo);
                    cmd.Parameters.AddWithValue("id_autor", obj.oAutor.id_autor);
                    cmd.Parameters.AddWithValue("id_categoria", obj.oCategoria.id_categoria);
                    cmd.Parameters.AddWithValue("descripcion", obj.descripcion);
                    cmd.Parameters.AddWithValue("precio_libro", obj.precio_libro);
                    cmd.Parameters.AddWithValue("stock_libro", obj.stock_libro);
                    cmd.Parameters.AddWithValue("imagen", obj.imagen);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);

                    cmd.Parameters.Add("IdLibroResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    idLibroGenerado = Convert.ToInt32(cmd.Parameters["IdLibroResultado"].Value);
                }
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                idLibroGenerado = 0;
            }
            return idLibroGenerado;
        }

        public bool Editar(Libros obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarLibro", con);
                    cmd.Parameters.AddWithValue("IdLibro", obj.id_libro);
                    cmd.Parameters.AddWithValue("Titulo", obj.titulo);
                    cmd.Parameters.AddWithValue("IdAutor", obj.oAutor.id_autor);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.oCategoria.id_categoria);
                    cmd.Parameters.AddWithValue("Descripcion", obj.descripcion);
                    cmd.Parameters.AddWithValue("Precio", obj.precio_libro);
                    cmd.Parameters.AddWithValue("Stock", obj.stock_libro);
                    cmd.Parameters.AddWithValue("Imagen", obj.imagen);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);

                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }

        public bool Eliminar(int idLibro, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarLibro", con);
                    cmd.Parameters.AddWithValue("IdLibro", idLibro);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }

        // --- Métodos para los ComboBox ---
        public List<Autor> ListarAutores()
        {
            List<Autor> lista = new List<Autor>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ListarAutores", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Autor()
                            {
                                id_autor = Convert.ToInt32(dr["id_autor"]),
                                nombre_autor = dr["nombre_autor"].ToString(),
                            });
                        }
                    }
                }
                catch (Exception ex) { lista = new List<Autor>(); }
            }
            return lista;
        }

        public List<Categoria> ListarCategorias()
        {
            List<Categoria> lista = new List<Categoria>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ListarCategorias", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Categoria()
                            {
                                id_categoria = Convert.ToInt32(dr["id_categoria"]),
                                nombre_categoria = dr["nombre_categoria"].ToString(),
                            });
                        }
                    }
                }
                catch (Exception ex) { lista = new List<Categoria>(); }
            }
            return lista;
        }

        public List<Libros> Listar2()
        {
            List<Libros> lista = new List<Libros>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT ");
                    // 1. Columnas de LIBRO
                    query.AppendLine("L.id_libro, L.titulo, L.precio_libro, L.stock_libro, L.descripcion, L.imagen, L.estado,");
                    // 2. Columnas de AUTOR
                    query.AppendLine("A.id_autor, A.nombre_autor,");
                    // 3. Columnas de CATEGORIA (¡Quitamos la coma de la última línea!)
                    query.AppendLine("C.id_categoria, C.nombre_categoria");

                    query.AppendLine("FROM libro L");
                    query.AppendLine("INNER JOIN autor A ON L.id_autor = A.id_autor");
                    query.AppendLine("INNER JOIN categoria C ON L.id_categoria = C.id_categoria");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Libros()
                            {
                                id_libro = Convert.ToInt32(dr["id_libro"]),
                                titulo = dr["titulo"].ToString(),
                                precio_libro = Convert.ToDecimal(dr["precio_libro"]),
                                stock_libro = Convert.ToInt32(dr["stock_libro"]),
                                descripcion = dr["descripcion"].ToString(),
                                imagen = dr["imagen"].ToString(),
                                Estado = Convert.ToBoolean(dr["estado"]),
                                // POBLAR OBJETOS RELACIONADOS:
                                oAutor = new Autor()
                                {
                                    id_autor = Convert.ToInt32(dr["id_autor"]),
                                    nombre_autor = dr["nombre_autor"].ToString()
                                },
                                oCategoria = new Categoria()
                                {
                                    id_categoria = Convert.ToInt32(dr["id_categoria"]),
                                    nombre_categoria = dr["nombre_categoria"].ToString()
                                }
                            });
                        }
                    }
                }
                catch
                {
                    lista = new List<Libros>();
                }
            }
            return lista;
        }
    }
}
