using HipodromoAPI.Models;

namespace HipodromoApi.Services
{
    public interface IMesaService
    {
        Mesa AsignarMesa(int numeroCubiertos);
        Mesa BuscarMesa(int numeroMesa);
        void LiberarMesa(int mesaId, int numeroCubiertos);
    }
}
