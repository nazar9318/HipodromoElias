using HipodromoAPI.Models;
using System;

namespace HipodromoAPI.Services
{
    public interface IClienteService
    {
        Cliente Buscar(int numeroCliente);
        string ObtenerNombreCliente(int numeroCliente);
        bool ClienteExiste(int numeroCliente, string nombreCliente);
    }
}
