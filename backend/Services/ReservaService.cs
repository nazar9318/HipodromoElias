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
        private readonly CategoriaService _categoriaService = new();

        public Reserva CrearReserva(int numeroCliente, string categoriaCliente, string nombre, DateTime fechaReserva, int cantidadPersonas)
        {
            if (fechaReserva.Date < DateTime.Now.Date)
            {
                throw new FechaInvalidaException();
            }

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
                PrioridadCliente = _categoriaService.ObtenerPrioridadCategoriaPor(categoriaCliente),
                FechaReserva = fechaReserva,
                CategoriaCliente = categoriaCliente,
                CantidadPersonas = cantidadPersonas,
                NombreCliente = nombre
            };

            var mesaDisponible = _mesaService.AsignarMesa(reserva, reservas);

            if (mesaDisponible != null)
            {
                reserva.NumeroMesa = mesaDisponible.NumeroMesa;
                reserva.EnListaEspera = false;
                reserva.CantidadPersonas = cantidadPersonas;
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
                PrioridadCliente = _categoriaService.ObtenerPrioridadCategoriaPor(categoriaCliente),
                FechaReserva = fechaReserva,
                EnListaEspera = true,
                CantidadPersonas = cantidadPersonas,
                NombreCliente = nombre
            };
            listaEspera.Add(reserva);
            return reserva;
        }

        public void LiberarMesaEnReserva(Reserva reserva)
        {
            if (listaEspera.Any())
            {
                var reservaEnEspera = listaEspera
                                        .Where(r => r.FechaReserva == reserva.FechaReserva && r.CantidadPersonas <= reserva.CantidadPersonas)
                                        .OrderBy(r => r.PrioridadCliente)
                                        .FirstOrDefault();
                if (reservaEnEspera != null)
                {
                    reservaEnEspera.NumeroMesa = (int)reserva.NumeroMesa;
                    reservaEnEspera.Id = reservas.Count + 1;
                    reservas.Add(reservaEnEspera);
                    listaEspera.Remove(reservaEnEspera);
                }
            }
        }

        public bool EliminarReserva(int idReserva)
        {
            var reserva = reservas.FirstOrDefault(r => r.Id == idReserva);
            if (reserva == null)
            {
                return false;
            }

            reservas.Remove(reserva);

            if (reserva.NumeroMesa.HasValue)
            {
                LiberarMesaEnReserva(reserva);
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
