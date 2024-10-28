using HipodromoAPI.Models;
using System;
using System.Collections.Generic;

namespace HipodromoAPI.Services
{
    public interface IClienteService
    {
        Cliente Buscar(int numeroCliente);
        string ObtenerNombreCliente(int numeroCliente);
        bool ClienteExiste(int numeroCliente, string nombreCliente);
        List<Cliente> ObtenerClientes();
    }
}
