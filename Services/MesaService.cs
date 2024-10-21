using HipodromoApi.Constants;
using HipodromoAPI.Models;
using System.Linq;

namespace NombreDelProyecto.Services
{
    public class MesaService
    {
        public Mesa AsignarMesa(int numeroCubiertos)
        {
            return MesaConstants.Mesas.FirstOrDefault(m => m.Cubiertos == numeroCubiertos && !m.Ocupada());
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
