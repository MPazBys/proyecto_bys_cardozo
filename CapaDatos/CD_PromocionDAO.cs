using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_PromocionDAO
    {
        // Método auxiliar para mapear el SqlDataReader a la entidad Promocion
        private Promocion MapearPromocion(SqlDataReader dr)
        {
            return new Promocion
            {
                IdPromocion = Convert.ToInt32(dr["id_promocion"]),
                Nombre = dr["nombre"].ToString(),
                Tipo = dr["tipo"].ToString(),
                ValorDescuento = Convert.ToDecimal(dr["valor_descuento"]),
                FechaInicio = Convert.ToDateTime(dr["fecha_inicio"]),
                FechaFin = Convert.ToDateTime(dr["fecha_fin"]),
                Estado = Convert.ToBoolean(dr["estado"]),
                IdItemAsociado = dr["IdItemAsociado"] != DBNull.Value ? Convert.ToInt32(dr["IdItemAsociado"]) : 0,
                DescripcionItemAsociado = dr["DescripcionItemAsociado"].ToString()
            };
        }


        // ==========================
        // LISTAR TODAS LAS PROMOCIONES
        // ==========================
        public List<Promocion> Listar()
        {
            List<Promocion> lista = new List<Promocion>();
            using (SqlConnection con = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_ListarPromociones", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(MapearPromocion(dr));
                }
            }
            return lista;
        }


        // ==========================
        // ELIMINAR PROMOCIÓN (Físicamente)
        // ==========================
        public bool Eliminar(int idPromocion)
        {
            using (SqlConnection con = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarPromocion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPromocion", idPromocion);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ==========================
        // INSERTAR NUEVA PROMOCIÓN (MODIFICADO)
        // ==========================
        public bool Insertar(Promocion p)
        {
            using (SqlConnection con = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarPromocion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                int idGenerado = 0;

                // Parámetros de entrada
                cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@TipoPromocion", p.Tipo);
                cmd.Parameters.AddWithValue("@ValorDescuento", p.ValorDescuento);
                cmd.Parameters.AddWithValue("@FechaInicio", p.FechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", p.FechaFin);
                cmd.Parameters.AddWithValue("@Activa", true); // Siempre activa al insertar
                // Manejo de IdItemAsociado
                cmd.Parameters.AddWithValue("@IdItemAsociado", p.IdItemAsociado == 0 ? (object)DBNull.Value : p.IdItemAsociado);

                // Parámetro de salida para el ID
                cmd.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;

                con.Open();
                cmd.ExecuteNonQuery();

                idGenerado = Convert.ToInt32(cmd.Parameters["@Resultado"].Value);
                return idGenerado != 0;
            }
        }

        // ==========================
        // EDITAR PROMOCIÓN (MODIFICADO)
        // ==========================
        public bool Editar(Promocion p)
        {
            bool resultado = false; // Inicializamos a falso
            using (SqlConnection con = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_EditarPromocion", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdPromocion", p.IdPromocion);
                cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@TipoPromocion", p.Tipo);
                cmd.Parameters.AddWithValue("@ValorDescuento", p.ValorDescuento);
                cmd.Parameters.AddWithValue("@FechaInicio", p.FechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", p.FechaFin);
                cmd.Parameters.AddWithValue("@Activa", p.Estado);
                cmd.Parameters.AddWithValue("@IdItemAsociado", p.IdItemAsociado == 0 ? (object)DBNull.Value : p.IdItemAsociado);

                // Parámetro de salida: CRÍTICO para recibir el resultado del SP
                SqlParameter paramResultado = cmd.Parameters.Add("@Resultado", SqlDbType.Bit);
                paramResultado.Direction = ParameterDirection.Output;

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();

                    // Capturar el valor devuelto por el SP
                    // Esto es lo que confirma si la transacción en SQL fue exitosa (1) o falló (0)
                    resultado = Convert.ToBoolean(paramResultado.Value);
                }
                catch (Exception ex)
                {
                    // La excepción solo se lanzará si hay un error grave de conexión o de sintaxis en el SP/SQL.
                    resultado = false;
                }
            }
            return resultado;
        }

        // ==========================
        // CAMBIAR ESTADO (Añadido)
        // ==========================
        public bool CambiarEstado(int idPromocion, bool nuevoEstado)
        {
            using (SqlConnection con = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_CambiarEstadoPromocion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPromocion", idPromocion);
                cmd.Parameters.AddWithValue("@NuevoEstado", nuevoEstado);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ====================================
        // OBTENER ITEMS ASOCIADOS (LIBRO, CAT, AUTOR, PAGO)
        // ====================================
        // NOTA: Este método requeriría SPs adicionales o consultas directas para cada tabla.
        // Lo simularemos devolviendo una lista de ItemDescuento (ID y Descripción).

        public List<ItemDescuento> ObtenerItemsAsociados(string tipo)
        {
            List<ItemDescuento> lista = new List<ItemDescuento>();
            string query = "";

            switch (tipo.ToLower())
            {
                case "libro":
                    // Asume que tienes una tabla 'libro' con id_libro y titulo
                    query = "SELECT id_libro AS Id, titulo AS Descripcion FROM libro ORDER BY titulo";
                    break;
                case "categoria":
                    // Asume que tienes una tabla 'categoria' con id_categoria y nombre_categoria
                    query = "SELECT id_categoria AS Id, nombre_categoria AS Descripcion FROM categoria ORDER BY nombre_categoria";
                    break;
                case "autor":
                    // Asume que tienes una tabla 'autor' con id_autor y nombre_autor
                    query = "SELECT id_autor AS Id, nombre_autor AS Descripcion FROM autor ORDER BY nombre_autor";
                    break;
                case "medio_pago":
                    // Asume que tienes una tabla 'medio_de_pago' con id_medio_de_pago y descripcion
                    query = "SELECT id_medio_de_pago AS Id, descripcion AS Descripcion FROM medio_de_pago ORDER BY descripcion";
                    break;
                default:
                    return lista;
            }

            using (SqlConnection con = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new ItemDescuento
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Descripcion = dr["Descripcion"].ToString()
                    });
                }
            }
            return lista;
        }

        // ==========================
        // FILTRAR PROMOCIONES
        // ==========================
        public List<Promocion> Filtrar(string tipo = null, bool? estado = null, DateTime? desde = null, DateTime? hasta = null)
        {
            List<Promocion> lista = new List<Promocion>();
            using (SqlConnection con = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_FiltrarPromociones", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Manejo de parámetros nulos: Se envían DBNull.Value si el parámetro es null
                cmd.Parameters.AddWithValue("@Tipo", (object)tipo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Estado", (object)estado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Desde", (object)desde ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Hasta", (object)hasta ?? DBNull.Value);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(MapearPromocion(dr));
                }
            }
            return lista;
        }

        //funcion para el reporte de gerente 

        public DataTable ListarPromocionesVigentes()
        {
            DataTable dt = new DataTable();
            
            using (SqlConnection con = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_ListarPromocionesVigentes", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    // Aquí deberías loguear tu error
                    Console.WriteLine(ex.Message);
                }
            }
            return dt;
        }

        public DataTable ReportePromocionesMasUsadas(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_ReportePromocionesMasUsadas", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@inicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@fin", fechaFin);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return dt;
        }
    }
}
