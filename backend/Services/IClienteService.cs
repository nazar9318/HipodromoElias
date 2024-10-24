using HipodromoAPI.Models;
using System;

namespace HipodromoAPI.Services
{
    public interface IClienteService
    {
        //Reserva HacerReserva(int numeroCliente, DateTime fechaReserva, int cantidadPersonas);
        Cliente Buscar(int numeroCliente);
        string ObtenerNombreCliente(int numeroCliente);
    }
}
