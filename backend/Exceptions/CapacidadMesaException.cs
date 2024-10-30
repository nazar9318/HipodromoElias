using System;

namespace HipodromoAPI.Exceptions
{
    public class CapacidadMesaException : Exception
    {
        public CapacidadMesaException()
            : base("La reserva supera la cantidad de cubiertos máximos en las mesas.")
        {
        }
    }
}
