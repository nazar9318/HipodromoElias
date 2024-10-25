using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HipodromoApi.Login
{
    public class LoginRequest
    {
        public string NombreLogin { get; set; }
        public int NumeroCliente { get; set; }
    }
}
