using HipodromoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HipodromoApi.Constants
{
    public static class CategoriaConstants
    {
        public const string Diamond = "Diamond";
        public const string Platinum = "Platinum";
        public const string Gold = "Gold";
        public const string Classic = "Classic";

        public static readonly string[] Todos = { Diamond, Platinum, Gold, Classic };
    }
}
