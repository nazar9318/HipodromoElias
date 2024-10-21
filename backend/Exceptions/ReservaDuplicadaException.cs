using System;

namespace HipodromoAPI.Exceptions
{
    public class ReservaDuplicadaException : Exception
    {
        public ReservaDuplicadaException()
            : base("El cliente ya tiene una reserva para esta fecha.")
        {
        }
    }
}
