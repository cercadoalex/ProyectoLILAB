﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class ProductoDto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public int CategoriaId { get; set; }
        public string CategoriaNombre { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
    }
}