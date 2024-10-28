using HipodromoAPI.Models;
using System;
using System.Collections.Generic;

namespace HipodromoAPI.Services
{
    public interface ICategoriaService
    {
        string ObtenerNombreCategoriaPor(int prioridad);
        int ObtenerPrioridadCategoriaPor(string nombreCategoria);
        List<Categoria> ObtenerCategorias();
    }
}
