using System;

namespace HipodromoAPI.Exceptions
{
    public class ClienteNoEncontradoException : Exception
    {
        public ClienteNoEncontradoException()
            : base("El cliente ingresado no existe")
        {
        }
    }
}
