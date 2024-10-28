using HipodromoAPI.Models;
using System.Collections.Generic;

namespace HipodromoApi.Services
{
    public interface IMesaService
    {
        Mesa AsignarMesa(Reserva reserva, List<Reserva> reservas);
        Mesa BuscarMesa(int numeroMesa);
        List<Mesa> ObtenerMesas();
    }
}
