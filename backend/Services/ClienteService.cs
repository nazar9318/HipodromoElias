using HipodromoApi.Constants;
using HipodromoAPI.Models;
using HipodromoAPI.Exceptions;
using System;
using System.Linq;
using HipodromoAPI.Services;

namespace HipodromoApi.Services
{
    public class ClienteService : IClienteService
    {

        /*public Reserva HacerReserva(int numeroCliente, DateTime fechaReserva, int cantidadPersonas)
        {
            var cliente = ClienteConstants.Clientes.FirstOrDefault(c => c.NumeroCliente == numeroCliente);
            if (cliente == null)
            {
                throw new ClienteNoEncontradoException();
            }

            return _reservaService.CrearReserva(numeroCliente, cliente.Categoria, fechaReserva, cantidadPersonas);
        }*/

        public Cliente Buscar(int numeroCliente)
        {
            var cliente = ClienteConstants.Clientes.FirstOrDefault(c => c.NumeroCliente == numeroCliente);
            if (cliente == null)
            {
                throw new ClienteNoEncontradoException();
            }

            return cliente;
        }

        public string ObtenerNombreCliente(int numeroCliente)
        {
            return ClienteConstants.Clientes.FirstOrDefault(c => c.NumeroCliente == numeroCliente).Nombre;
        }
    }
}
