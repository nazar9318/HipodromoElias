using HipodromoAPI.Models;
using System;

namespace HipodromoAPI.Services
{
    public interface ICategoriaService
    {
        string ObtenerNombreCategoriaPor(int prioridad);
        int ObtenerPrioridadCategoriaPor(string nombreCategoria);
    }
}
