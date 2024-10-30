using HipodromoApi.Constants;
using HipodromoAPI.Exceptions;
using HipodromoAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace HipodromoApi.Services
{
    public class MesaService : IMesaService
    {
        public Mesa AsignarMesa(Reserva reserva, List<Reserva> listaReservas)
        {
            if (reserva.CantidadPersonas > MesaConstants.Mesas.OrderByDescending(m => m.Cubiertos).FirstOrDefault().Cubiertos)
            {
                throw new CapacidadMesaException();
            }

            return MesaConstants.Mesas.FirstOrDefault(mesa =>
            {
                int personasYaReservadas = listaReservas
                    .Where(r => r.NumeroMesa == mesa.NumeroMesa && r.FechaReserva.Date == reserva.FechaReserva.Date)
                    .Sum(r => r.CantidadPersonas);

                return (personasYaReservadas + reserva.CantidadPersonas) <= mesa.Cubiertos;
            });
        }

        public Mesa BuscarMesa(int numeroMesa)
        {
            return MesaConstants.Mesas.FirstOrDefault(m => m.NumeroMesa == numeroMesa);
        }

        public List<Mesa> ObtenerMesas()
        {
            return MesaConstants.Mesas.ToList();
        }
    }
}
