using HipodromoApi.Constants;
using HipodromoAPI.Exceptions;
using HipodromoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

public class ReservaService : IReservaService
{
    private List<Reserva> reservas = new List<Reserva>();
    private List<Mesa> mesas = MesaConstants.Mesas;
    private List<Reserva> listaEspera = new List<Reserva>();

    public Reserva CrearReserva(int numeroCliente, string categoriaCliente, DateTime fechaReserva, int cantidadPersonas)
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
            CantidadPersonas = cantidadPersonas
        };

        var mesaDisponible = mesas.FirstOrDefault(m => m.Soporta(cantidadPersonas));

        // Asignar mesa si hay disponibilidad
        if (mesaDisponible != null)
        {
            mesaDisponible.Reservar(cantidadPersonas);
            reserva.NumeroMesa = mesaDisponible.NumeroMesa;
            reserva.EnListaEspera = false;
            reservas.Add(reserva);
        }
        // Añadir a la lista de espera si no hay mesas disponibles
        else
        {
            reserva.EnListaEspera = true;
            listaEspera.Add(reserva);
        }

        return reserva;
    }

    public Reserva AgregarAListaEspera(int numeroCliente, string categoriaCliente, int cantidadPersonas)
    {
        var reserva = new Reserva
        {
            Id = reservas.Count + 1,
            NumeroCliente = numeroCliente,
            CategoriaCliente = categoriaCliente,
            EnListaEspera = true,
            CantidadPersonas = cantidadPersonas
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
            var mesaLiberada = mesas.FirstOrDefault(m => m.NumeroMesa == reserva.NumeroMesa.Value);
            if (mesaLiberada != null)
            {
                mesaLiberada.Liberar(reserva.CantidadPersonas);
            }

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
