using HipodromoApi.Services;
using HipodromoAPI.Exceptions;
using Xunit;

namespace HipodromoAPI.Tests
{
    public class ClienteServiceTests
    {
        private readonly ClienteService _clienteService;

        public ClienteServiceTests()
        {
            _clienteService = new ClienteService();
        }

        [Fact]
        public void Buscar_ExistingClient_ShouldReturnClient()
        {
            var client = _clienteService.Buscar(1);

            Assert.NotNull(client);
            Assert.Equal("Juan Pérez", client.Nombre);
        }

        [Fact]
        public void Buscar_NonExistingClient_ShouldThrowException()
        {
            var exception = Assert.Throws<ClienteNoEncontradoException>(() =>
                _clienteService.Buscar(999)
            );

            Assert.Equal("El cliente ingresado no existe", exception.Message);
        }

        [Fact]
        public void ClienteExiste_ExistingClient_ShouldReturnTrue()
        {
            var exists = _clienteService.ClienteExiste(1, "Juan Pérez");

            Assert.True(exists);
        }

        [Fact]
        public void ObtenerNombreCliente_ExistingClient_ShouldReturnName()
        {
            var name = _clienteService.ObtenerNombreCliente(1);

            Assert.Equal("Juan Pérez", name);
        }
    }
}
