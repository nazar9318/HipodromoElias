using HipodromoApi.Constants;
using HipodromoAPI.Exceptions;
using HipodromoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HipodromoApi.Services
{
    public interface IReservaService
    {
        Reserva CrearReserva(int numeroCliente, string categoriaCliente, string nombre, DateTime fechaReserva, int cantidadPersonas);
        List<Reserva> ObtenerReservas();
        List<Reserva> ObtenerListaEspera();
        bool EliminarReserva(int idReserva);
        Reserva AgregarAListaEspera(int numeroCliente, string categoriaCliente, string nombre, DateTime fechaReserva, int cantidadPersonas);
    }
}
