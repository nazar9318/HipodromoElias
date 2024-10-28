using HipodromoApi.Constants;
using HipodromoAPI.Models;
using HipodromoAPI.Exceptions;
using System;
using System.Linq;
using HipodromoAPI.Services;
using System.Collections.Generic;

namespace HipodromoApi.Services
{
    public class ClienteService : IClienteService
    {
        public Cliente Buscar(int numeroCliente)
        {
            var cliente = ClienteConstants.Clientes.FirstOrDefault(c => c.NumeroCliente == numeroCliente);
            if (cliente == null)
            {
                throw new ClienteNoEncontradoException();
            }

            return cliente;
        }

        public bool ClienteExiste(int numeroCliente, string nombreCliente)
        {
            return (ClienteConstants.Clientes.FirstOrDefault(c => c.Nombre == nombreCliente && c.NumeroCliente == numeroCliente)) != null;
        }

        public List<Cliente> ObtenerClientes()
        {
            return ClienteConstants.Clientes.ToList();
        }

        public string ObtenerNombreCliente(int numeroCliente)
        {
            return Buscar(numeroCliente).Nombre;
        }
    }
}
