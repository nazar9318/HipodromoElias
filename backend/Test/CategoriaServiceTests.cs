using HipodromoApi.Services;
using Xunit;

namespace HipodromoAPI.Tests
{
    public class CategoriaServiceTests
    {
        private readonly CategoriaService _categoriaService;

        public CategoriaServiceTests()
        {
            _categoriaService = new CategoriaService();
        }

        [Fact]
        public void ObtenerNombreCategoriaPor_ExistingPriority_ShouldReturnName()
        {
            var name = _categoriaService.ObtenerNombreCategoriaPor(1);

            Assert.Equal("Diamond", name);
        }

        [Fact]
        public void ObtenerPrioridadCategoriaPor_ExistingName_ShouldReturnPriority()
        {
            var priority = _categoriaService.ObtenerPrioridadCategoriaPor("Gold");

            Assert.Equal(3, priority);
        }
    }
}
