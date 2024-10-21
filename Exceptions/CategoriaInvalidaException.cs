using System;

namespace HipodromoAPI.Exceptions
{
    public class CategoriaInvalidaException : Exception
    {
        public CategoriaInvalidaException()
            : base("El cliente no tiene la categoría que corresponde para reservar en la fecha indicada.")
        {
        }
    }
}
