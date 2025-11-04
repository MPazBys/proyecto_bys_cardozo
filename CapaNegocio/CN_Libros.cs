using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;



namespace CapaNegocio
{
    public class CN_Libros
    {
        private CD_Libros objCD_Libro = new CD_Libros();

        public List<Libros> Listar()
        {
            return objCD_Libro.Listar();
        }

        public int Insertar(Libros obj, out string Mensaje)
        {
            // --- REGLAS DE NEGOCIO ---
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.titulo))
            {
                Mensaje = "El título del libro no puede estar vacío.";
                return 0;
            }
            if (obj.oAutor.id_autor == 0)
            {
                Mensaje = "Debe seleccionar un autor.";
                return 0;
            }
            if (obj.oCategoria.id_categoria == 0)
            {
                Mensaje = "Debe seleccionar una categoría.";
                return 0;
            }
            if (obj.precio_libro <= 0)
            {
                Mensaje = "El precio debe ser mayor a cero.";
                return 0;
            }
            if (obj.stock_libro < 0)
            {
                Mensaje = "El stock no puede ser negativo.";
                return 0;
            }
            // --- Fin Reglas de Negocio ---

            return objCD_Libro.Insertar(obj, out Mensaje);
        }

        public bool Editar(Libros obj, out string Mensaje)
        {
            // Puedes agregar reglas de negocio similares aquí
            return objCD_Libro.Editar(obj, out Mensaje);
        }

        public bool Eliminar(int idLibro, out string Mensaje)
        {
            return objCD_Libro.Eliminar(idLibro, out Mensaje);
        }

        // --- Métodos para ComboBox ---
        public List<Autor> ListarAutores()
        {
            return objCD_Libro.ListarAutores();
        }
        public List<Categoria> ListarCategorias()
        {
            return objCD_Libro.ListarCategorias();
        }

        private CD_Libros oCD_libro = new CD_Libros();

        public List<Libros> Listar2()
        {
            return oCD_libro.Listar();
        }

        public List<Libros> BuscarPorNombre(string texto)
        {
            texto = texto.ToLower();
            return oCD_libro.Listar2()
                .Where(l => l.titulo.ToLower().Contains(texto)).ToList();
        }
    }
}
