﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Libros
    {
        public int id_libro{ get; set; }
        public string titulo { get; set; }
        public float precio_libro { get; set; }
        public int stock_libro { get; set; }
        public string descripcion { get; set; }
        public string imagen { get; set; }
        

    }
}
