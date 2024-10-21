namespace HipodromoAPI.Models
{
    public class Mesa
    {
        public int NumeroMesa { get; set; }
        public int Cubiertos { get; set; }
        public int PersonasOcupando { get; set; }
        public bool Ocupada()
        {
            return !(Cubiertos > PersonasOcupando);
        }
        public bool Soporta(int cantidad)
        {
            return ((Cubiertos - PersonasOcupando) >= cantidad);
        }
        public void Reservar(int cantidad)
        {
            PersonasOcupando += cantidad;
        }
        public void Liberar(int cantidad)
        {
            PersonasOcupando -= cantidad;
        }
    }
}
