using HipodromoApi.Constants;
using HipodromoApi.Services;
using HipodromoAPI.Exceptions;
using HipodromoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HipodromoApi.Services
{
    public class ReservaService : IReservaService
    {
        private List<Reserva> reservas = new List<Reserva>();
        private List<Reserva> listaEspera = new List<Reserva>();
        private readonly MesaService _mesaService = new();

        public Reserva CrearReserva(int numeroCliente, string categoriaCliente, string nombre, DateTime fechaReserva, int cantidadPersonas)
        {
            if (!PuedeReservar(categoriaCliente, fechaReserva))
            {
                throw new CategoriaInvalidaException();
            }

            if (reservas.Any(r => r.NumeroCliente == numeroCliente && r.FechaReserva.Date == fechaReserva.Date))
            {
                throw new ReservaDuplicadaException();
            }

            var reserva = new Reserva
            {
                Id = reservas.Count + 1,
                NumeroCliente = numeroCliente,
                FechaReserva = fechaReserva,
                CategoriaCliente = categoriaCliente,
                NombreCliente = nombre
            };

            var mesaDisponible = _mesaService.AsignarMesa(cantidadPersonas);

            // Asignar mesa si hay disponibilidad
            if (mesaDisponible != null)
            {
                reserva.NumeroMesa = mesaDisponible.NumeroMesa;
                reserva.EnListaEspera = false;
                reservas.Add(reserva);
            }

            return reserva;
        }

        public Reserva AgregarAListaEspera(int numeroCliente, string categoriaCliente, string nombre, DateTime fechaReserva, int cantidadPersonas)
        {
            var reserva = new Reserva
            {
                Id = listaEspera.Count + 1,
                NumeroCliente = numeroCliente,
                CategoriaCliente = categoriaCliente,
                FechaReserva = fechaReserva,
                EnListaEspera = true,
                CantidadPersonas = cantidadPersonas,
                NombreCliente = nombre
            };
            listaEspera.Add(reserva);
            return reserva;
        }

        public bool EliminarReserva(int idReserva)
        {
            var reserva = reservas.FirstOrDefault(r => r.Id == idReserva);
            if (reserva == null)
            {
                return false;
            }

            reservas.Remove(reserva);

            // Liberar mesa si tenía una asignada
            if (reserva.NumeroMesa.HasValue)
            {
                _mesaService.LiberarMesa((int)reserva.NumeroMesa, reserva.CantidadPersonas);

                // Reasignar la mesa al cliente en la lista de espera más prioritario
                if (listaEspera.Any())
                {
                    var reservaEnEspera = listaEspera.OrderBy(c => c.CategoriaCliente).First();
                    reservas.Add(reservaEnEspera);
                    listaEspera.Remove(reservaEnEspera);
                }
            }

            return true;
        }

        public bool PuedeReservar(string categoriaCliente, DateTime fechaReserva)
        {
            TimeSpan tiempoRestante = fechaReserva - DateTime.Now;

            return categoriaCliente switch
            {
                "Classic" => Math.Ceiling(tiempoRestante.TotalHours - 48) >= 0,
                "Gold" => Math.Ceiling(tiempoRestante.TotalHours - 72) >= 0,
                "Platinum" => Math.Ceiling(tiempoRestante.TotalHours - 96) >= 0,
                "Diamond" => true,
                _ => false,
            };
        }

        public List<Reserva> ObtenerReservas() => reservas;
        public List<Reserva> ObtenerListaEspera() => listaEspera;
    }

}
