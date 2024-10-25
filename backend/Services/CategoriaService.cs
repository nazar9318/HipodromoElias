using HipodromoApi.Constants;
using HipodromoAPI.Models;
using HipodromoAPI.Exceptions;
using System;
using System.Linq;
using HipodromoAPI.Services;

namespace HipodromoApi.Services
{
    public class CategoriaService : ICategoriaService
    {
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
