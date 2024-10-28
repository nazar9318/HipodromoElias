using HipodromoApi.Constants;
using HipodromoAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace HipodromoApi.Services
{
    public class MesaService : IMesaService
    {        
        public Mesa AsignarMesa(Reserva reserva, List<Reserva> listaReservas)
        {
            return MesaConstants.Mesas.FirstOrDefault(mesa =>
            {
                // Sumar las personas que ya han reservado en esta mesa para la fecha específica
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
    }
}
