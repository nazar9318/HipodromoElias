using HipodromoApi.Constants;
using HipodromoAPI.Models;
using HipodromoAPI.Exceptions;
using System;
using System.Linq;
using HipodromoAPI.Services;
using System.Collections.Generic;

namespace HipodromoApi.Services
{
    public class CategoriaService : ICategoriaService
    {
        public List<Categoria> ObtenerCategorias()
        {
            return CategoriaConstants.Categorias.ToList();
        }

        public string ObtenerNombreCategoriaPor(int prioridad)
        {
            return CategoriaConstants.Categorias.FirstOrDefault(c => c.Prioridad == prioridad).Nombre;
        }

        public int ObtenerPrioridadCategoriaPor(string nombreCategoria)
        {
            return CategoriaConstants.Categorias.FirstOrDefault(c => c.Nombre == nombreCategoria).Prioridad;
        }
    }
}
