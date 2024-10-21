using System;

namespace HipodromoAPI.Exceptions
{
    public class ReservaNoExisteException : Exception
    {
        public ReservaNoExisteException()
            : base("La reserva para el cliente y la fecha provistos no existe.")
        {
        }
    }
}
