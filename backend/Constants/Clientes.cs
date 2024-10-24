using HipodromoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HipodromoApi.Constants
{
    public static class ClienteConstants
    {
        public static readonly List<Cliente> Clientes = new()
        {
            new Cliente { NumeroCliente = 1, Nombre = "Juan Pérez", Categoria = "Classic" },
            new Cliente { NumeroCliente = 2, Nombre = "María Gómez", Categoria = "Gold" },
            new Cliente { NumeroCliente = 3, Nombre = "Pedro López", Categoria = "Platinum" },
            new Cliente { NumeroCliente = 4, Nombre = "Ana Torres", Categoria = "Diamond" },
            new Cliente { NumeroCliente = 5, Nombre = "Luis Fernández", Categoria = "Classic" },
            new Cliente { NumeroCliente = 6, Nombre = "Laura Martínez", Categoria = "Gold" },
            new Cliente { NumeroCliente = 7, Nombre = "Carlos Ramírez", Categoria = "Platinum" },
            new Cliente { NumeroCliente = 8, Nombre = "Sofía Castillo", Categoria = "Diamond" },
            new Cliente { NumeroCliente = 9, Nombre = "Miguel Ángel", Categoria = "Classic" },
            new Cliente { NumeroCliente = 10, Nombre = "Fernanda Sánchez", Categoria = "Gold" },
            new Cliente { NumeroCliente = 11, Nombre = "Diego Jiménez", Categoria = "Platinum" },
            new Cliente { NumeroCliente = 12, Nombre = "Gabriela Ruiz", Categoria = "Diamond" },
            new Cliente { NumeroCliente = 13, Nombre = "Ricardo Torres", Categoria = "Classic" },
            new Cliente { NumeroCliente = 14, Nombre = "Valentina Silva", Categoria = "Gold" },
            new Cliente { NumeroCliente = 15, Nombre = "Nicolás Castillo", Categoria = "Platinum" },
            new Cliente { NumeroCliente = 16, Nombre = "Camila Morales", Categoria = "Diamond" },
            new Cliente { NumeroCliente = 17, Nombre = "Andrés Martínez", Categoria = "Classic" },
            new Cliente { NumeroCliente = 18, Nombre = "Mariana González", Categoria = "Gold" },
            new Cliente { NumeroCliente = 19, Nombre = "Javier Peña", Categoria = "Platinum" },
            new Cliente { NumeroCliente = 20, Nombre = "Isabella Romero", Categoria = "Diamond" },
        };
    }
}
