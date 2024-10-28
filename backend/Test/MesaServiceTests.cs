using HipodromoApi.Constants;
using HipodromoApi.Services;
using HipodromoAPI.Exceptions;
using HipodromoAPI.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace HipodromoApi.Tests
{
    public class MesaServiceTests
    {
        private MesaService _mesaService;

        public MesaServiceTests()
        {
            _mesaService = new MesaService();
        }

        [Fact]
        public void AsignarMesa_ShouldReturnAvailableTable()
        {
            var reserva = new Reserva { CantidadPersonas = 2, FechaReserva = DateTime.Now };
            var listaReservas = new List<Reserva>();

            var mesa = _mesaService.AsignarMesa(reserva, listaReservas);

            Assert.NotNull(mesa);
            Assert.Equal(2, mesa.Cubiertos);
        }

        [Fact]
        public void AsignarMesa_ShouldNotReturnTableIfNoAvailability()
        {
            var reserva = new Reserva { CantidadPersonas = 10, FechaReserva = DateTime.Now };
            var listaReservas = new List<Reserva>
            {
                new Reserva { NumeroMesa = 1, CantidadPersonas = 6, FechaReserva = DateTime.Now },
                new Reserva { NumeroMesa = 2, CantidadPersonas = 4, FechaReserva = DateTime.Now }
            };

            var mesa = _mesaService.AsignarMesa(reserva, listaReservas);

            Assert.Null(mesa);
        }
    }
}
