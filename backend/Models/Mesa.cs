namespace HipodromoAPI.Models
{
    public class Mesa
    {
        public int NumeroMesa { get; set; }
        public int Cubiertos { get; set; }
        public int PersonasOcupando { get; set; }
        public bool Soporta(int cantidad)
        {
            return Cubiertos >= cantidad;
        }
    }
}
