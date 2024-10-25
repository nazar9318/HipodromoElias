using HipodromoApi.Constants;
using HipodromoAPI.Models;
using System.Linq;

namespace HipodromoApi.Services
{
    public class MesaService : IMesaService
    {
        public Mesa AsignarMesa(int numeroCubiertos)
        {
            var mesaDisponible = MesaConstants.Mesas.FirstOrDefault(m => m.Soporta(numeroCubiertos) && !m.Ocupada());
            if (mesaDisponible != null)
            {
                mesaDisponible.Reservar(numeroCubiertos);
            }
            return mesaDisponible;
        }

        public Mesa BuscarMesa(int numeroMesa)
        {
            return MesaConstants.Mesas.FirstOrDefault(m => m.NumeroMesa == numeroMesa);
        }

        public void LiberarMesa(int mesaId, int numeroCubiertos)
        {
            var mesa = MesaConstants.Mesas.FirstOrDefault(m => m.NumeroMesa == mesaId);
            if (mesa != null)
            {
                mesa.Liberar(numeroCubiertos);
            }
        }
    }
}
