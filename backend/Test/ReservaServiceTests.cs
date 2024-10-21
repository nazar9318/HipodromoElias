using HipodromoApi.Constants;
using HipodromoAPI.Exceptions;
using System;
using System.Linq;
using Xunit;

namespace HipodromoAPI.Tests
{
    public class ReservaServiceTests
    {
        private readonly ReservaService _reservaService;

        public ReservaServiceTests()
        {
            _reservaService = new ReservaService();
        }

        [Fact]
        public void CrearReserva_ShouldAssignTable_WhenAvailable()
        {
            var numeroCliente = 1;
            var categoriaCliente = "Diamond";
            var fechaReserva = DateTime.Now;
            
            var reserva = _reservaService.CrearReserva(numeroCliente, categoriaCliente, fechaReserva, 1);

            Assert.NotNull(reserva.NumeroMesa);
            Assert.False(reserva.EnListaEspera);
        }

        [Fact]
        public void CrearReserva_ShouldAddToWaitlist_WhenNoTablesAvailable()
        {
            var numeroCliente1 = 1;
            var categoriaCliente1 = "Diamond";
            var fechaReserva = DateTime.Now;

            _reservaService.CrearReserva(numeroCliente1, categoriaCliente1, fechaReserva, 1);
            for (int i = 2; i <= 144; i++)
            {
                _reservaService.CrearReserva(i, "Diamond", fechaReserva, 1);
            }
            var reservaEnEspera = _reservaService.CrearReserva(145, "Diamond", fechaReserva, 1);

            Assert.True(reservaEnEspera.EnListaEspera);
            Assert.Null(reservaEnEspera.NumeroMesa);
        }

        [Fact]
        public void EliminarReserva_ShouldRemoveReservation_WhenExists()
        {
            var numeroCliente = 1;
            var categoriaCliente = "Diamond";
            var fechaReserva = DateTime.Now;
            var reserva = _reservaService.CrearReserva(numeroCliente, categoriaCliente, fechaReserva, 1);
            var reservaId = reserva.Id;

            var result = _reservaService.EliminarReserva(reservaId);

            Assert.True(result);
            Assert.Empty(_reservaService.ObtenerReservas());
        }

        [Fact]
        public void EliminarReserva_ShouldNotRemove_WhenNotExists()
        {
            var result = _reservaService.EliminarReserva(999);

            Assert.False(result);
        }

        [Fact]
        public void CrearReserva_ShouldThrowReservaDuplicadaException_WhenClientAlreadyHasReservation()
        {
            var numeroCliente = 1;
            var categoriaCliente = "Diamond";
            var fechaReserva = DateTime.Now;

            _reservaService.CrearReserva(numeroCliente, categoriaCliente, fechaReserva, 1);

            var exception = Assert.Throws<ReservaDuplicadaException>(() =>
                _reservaService.CrearReserva(numeroCliente, categoriaCliente, fechaReserva, 1)
            );

            Assert.Equal("El cliente ya tiene una reserva para esta fecha.", exception.Message);
        }

        [Fact]
        public void ObtenerReservas_ShouldReturnListOfReservations()
        {
            var numeroCliente = 1;
            var categoriaCliente = "Diamond";
            var fechaReserva = DateTime.Now;

            _reservaService.CrearReserva(numeroCliente, categoriaCliente, fechaReserva, 1);
            var reservas = _reservaService.ObtenerReservas();

            Assert.Single(reservas);
            Assert.Equal(numeroCliente, reservas.First().NumeroCliente);
        }

        [Fact]
        public void ObtenerListaEspera_ShouldReturnListOfWaitlistClients()
        {
            var numeroCliente1 = 1;
            var categoriaCliente1 = "Diamond";
            var fechaReserva = DateTime.Now;

            _reservaService.CrearReserva(numeroCliente1, categoriaCliente1, fechaReserva, 1);
            for (int i = 2; i <= 145; i++)
            {
                _reservaService.CrearReserva(i, "Diamond", fechaReserva, 1);
            }
            var listaEspera = _reservaService.ObtenerListaEspera();


            Assert.Single(listaEspera);
            Assert.Equal(145, listaEspera.First().NumeroCliente);
        }

        [Fact]
        public void EliminarReserva_ShouldReassignTableToWaitlistedClient_WhenTableBecomesAvailable()
        {
            var numeroCliente1 = 1;
            var categoriaCliente1 = "Diamond";
            var fechaReserva = DateTime.Now;

            var reserva1 = _reservaService.CrearReserva(numeroCliente1, categoriaCliente1, fechaReserva, 1);
            
            for (int i = 2; i <= 145; i++)
            {
                _reservaService.CrearReserva(i, "Diamond", fechaReserva, 1);
            }

            var waitlist = _reservaService.ObtenerListaEspera();
            Assert.NotEmpty(waitlist);

            _reservaService.EliminarReserva(reserva1.Id);
            Assert.Empty(waitlist);
        }

        [Fact]
        public void CrearReserva_ShouldAllowClassicReservation_When48HoursBefore()
        {
            var fechaReserva = DateTime.Now.AddHours(48);
            var numeroCliente = 1;

            var reserva = _reservaService.CrearReserva(numeroCliente, CategoriaConstants.Classic.ToString(), fechaReserva, 1);

            Assert.NotNull(reserva);
        }

        [Fact]
        public void CrearReserva_ShouldAllowGoldReservation_When72HoursBefore()
        {
            var fechaReserva = DateTime.Now.AddHours(72);
            var numeroCliente = 2;

            var reserva = _reservaService.CrearReserva(numeroCliente, CategoriaConstants.Gold.ToString(), fechaReserva, 1);

            Assert.NotNull(reserva);
        }

        [Fact]
        public void CrearReserva_ShouldAllowPlatinumReservation_When96HoursBefore()
        {
            var fechaReserva = DateTime.Now.AddHours(96);
            var numeroCliente = 3;

            var reserva = _reservaService.CrearReserva(numeroCliente, CategoriaConstants.Platinum.ToString(), fechaReserva, 1);

            Assert.NotNull(reserva);
        }

        [Fact]
        public void CrearReserva_ShouldAllowDiamondReservation_WhenAnyTime()
        {
            var fechaReserva = DateTime.Now;
            var numeroCliente = 4;

            var reserva = _reservaService.CrearReserva(numeroCliente, CategoriaConstants.Diamond.ToString(), fechaReserva, 1);

            Assert.NotNull(reserva);
        }

        [Fact]
        public void CrearReserva_ShouldNotAllowClassicReservation_WhenLessThan48Hours()
        {
            var fechaReserva = DateTime.Now.AddHours(47);
            var numeroCliente = 5;

            var exception = Assert.Throws<CategoriaInvalidaException>(() =>
                _reservaService.CrearReserva(numeroCliente, CategoriaConstants.Classic.ToString(), fechaReserva, 1)
            );

            Assert.Equal("El cliente no tiene la categoría que corresponde para reservar en la fecha indicada.", exception.Message);
        }

        [Fact]
        public void CrearReserva_ShouldNotAllowGoldReservation_WhenLessThan72Hours()
        {
            var fechaReserva = DateTime.Now.AddHours(71);
            var numeroCliente = 6;

            var exception = Assert.Throws<CategoriaInvalidaException>(() =>
                _reservaService.CrearReserva(numeroCliente, CategoriaConstants.Gold.ToString(), fechaReserva, 1)
            );

            Assert.Equal("El cliente no tiene la categoría que corresponde para reservar en la fecha indicada.", exception.Message);
        }

        [Fact]
        public void CrearReserva_ShouldNotAllowPlatinumReservation_WhenLessThan96Hours()
        {
            var fechaReserva = DateTime.Now.AddHours(95);
            var numeroCliente = 7;
            
            var exception = Assert.Throws<CategoriaInvalidaException>(() =>
                _reservaService.CrearReserva(numeroCliente, CategoriaConstants.Platinum.ToString(), fechaReserva, 1)
            );

            Assert.Equal("El cliente no tiene la categoría que corresponde para reservar en la fecha indicada.", exception.Message);
        }
    }
}
