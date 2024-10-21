using System;

namespace HipodromoAPI.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public int NumeroCliente { get; set; }
        public DateTime FechaReserva { get; set; }
        public int? NumeroMesa { get; set; }
        public int CantidadPersonas { get; set; }
        public string CategoriaCliente { get; set; }
        public bool EnListaEspera { get; set; }
    }
}
