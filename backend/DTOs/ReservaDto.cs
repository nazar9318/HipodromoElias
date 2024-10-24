using System;

namespace HipodromoAPI.Dtos
{
    public class ReservaDto
    {
        public int NumeroCliente { get; set; }
        public DateTime FechaReserva { get; set; }
        public int CantidadPersonas { get; set; }
    }
}
