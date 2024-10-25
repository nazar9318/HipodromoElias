using HipodromoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HipodromoApi.Constants
{
    public static class CategoriaConstants
    {
        public static List<Categoria> Categorias = new List<Categoria>
        {
            new Categoria { Prioridad = 1, Nombre = "Diamond" },
            new Categoria { Prioridad = 2, Nombre = "Platinum" },
            new Categoria { Prioridad = 3, Nombre = "Gold" },
            new Categoria { Prioridad = 4, Nombre = "Classic" },
        };
    }
}
