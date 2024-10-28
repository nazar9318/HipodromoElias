using System;

namespace HipodromoAPI.Exceptions
{
    public class FechaInvalidaException : Exception
    {
        public FechaInvalidaException()
            : base("¡No se puede reservar para fechas previas a hoy!")
        {
        }
    }
}
