using HipodromoApi.Constants;
using HipodromoApi.Services;
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
            
            var reserva = _reservaService.CrearReserva(numeroCliente, categoriaCliente, "Federico", fechaReserva, 1);

            Assert.NotNull(reserva.NumeroMesa);
            Assert.False(reserva.EnListaEspera);
        }

        [Fact]
        public void CrearReserva_ShouldAssignSameTable_WhenDatesAreDifferents()
        {
            var reserva1 = _reservaService.CrearReserva(1, "Diamond", "Federico", DateTime.Now, 2);
            var reserva2 = _reservaService.CrearReserva(2, "Diamond", "Daniel", DateTime.Now.AddDays(1), 2);

            Assert.Equal(1, reserva2.NumeroMesa);
        }

        [Fact]
        public void CrearReserva_ShouldNotAllowReservations_BeforeDateNow()
        {
            var exception = Assert.Throws<FechaInvalidaException>(() =>
                _reservaService.CrearReserva(1, "Diamond", "Federico", DateTime.Now.AddDays(-1), 2)
            );

            Assert.Equal("¡No se puede reservar para fechas previas a hoy!", exception.Message);
        }

        [Fact]
        public void CrearReserva_ShouldReturnEmpty_WhenNoTablesAvailable()
        {
            var numeroCliente1 = 1;
            var categoriaCliente1 = "Diamond";
            var fechaReserva = DateTime.Now;

            _reservaService.CrearReserva(numeroCliente1, categoriaCliente1, "Federico", fechaReserva, 6);
            for (int i = 2; i <= 10; i++)
            {
                _reservaService.CrearReserva(i, "Diamond", "Federico", fechaReserva, 6);
            }
            var reservaEnEspera = _reservaService.CrearReserva(11, "Diamond", "Federico", fechaReserva, 6);

            Assert.Null(reservaEnEspera.NumeroMesa);
        }

        [Fact]
        public void EliminarReserva_ShouldRemoveReservation_WhenExists()
        {
            var numeroCliente = 1;
            var categoriaCliente = "Diamond";
            var fechaReserva = DateTime.Now;
            var reserva = _reservaService.CrearReserva(numeroCliente, categoriaCliente, "Federico", fechaReserva, 1);
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

            _reservaService.CrearReserva(numeroCliente, categoriaCliente, "Federico", fechaReserva, 1);

            var exception = Assert.Throws<ReservaDuplicadaException>(() =>
                _reservaService.CrearReserva(numeroCliente, categoriaCliente, "Federico", fechaReserva, 1)
            );

            Assert.Equal("El cliente ya tiene una reserva para esta fecha.", exception.Message);
        }

        [Fact]
        public void ObtenerReservas_ShouldReturnListOfReservations()
        {
            var numeroCliente = 1;
            var categoriaCliente = "Diamond";
            var fechaReserva = DateTime.Now;

            _reservaService.CrearReserva(numeroCliente, categoriaCliente, "Federico", fechaReserva, 1);
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

            _reservaService.AgregarAListaEspera(numeroCliente1, categoriaCliente1, "Federico", fechaReserva, 1);

            var listaEspera = _reservaService.ObtenerListaEspera();

            Assert.Single(listaEspera);
            Assert.Equal(1, listaEspera.First().NumeroCliente);
        }

        [Fact]
        public void EliminarReserva_ShouldReassignTableToWaitlistedClient_WhenTableBecomesAvailable()
        {
            var numeroCliente1 = 1;
            var categoriaCliente1 = "Diamond";
            var fechaReserva = DateTime.Now;

            var reserva1 = _reservaService.CrearReserva(numeroCliente1, categoriaCliente1, "Federico", fechaReserva, 1);
            
            _reservaService.AgregarAListaEspera(2, "Diamond", "Federico", fechaReserva, 1);

            var waitlist = _reservaService.ObtenerListaEspera();
            Assert.NotEmpty(waitlist);

            _reservaService.EliminarReserva(reserva1.Id);
            Assert.Empty(waitlist);
        }

        [Fact]
        public void ReasignarMesaAReservaEnEspera_ShouldNotAssignTableToWaitList_IfDatesDontMatch()
        {
            var numeroCliente1 = 1;
            var categoriaCliente1 = "Diamond";
            var fechaReserva = DateTime.Now;
            var fechaEspera = DateTime.Now.AddDays(1);
            var reserva1 = _reservaService.CrearReserva(numeroCliente1, categoriaCliente1, "Federico", fechaReserva, 1);
            _reservaService.AgregarAListaEspera(2, "Diamond", "Daniel", fechaEspera, 1);

            _reservaService.EliminarReserva(reserva1.Id);

            Assert.DoesNotContain(_reservaService.ObtenerReservas(), r => r.NumeroMesa == reserva1.NumeroMesa && r.NumeroCliente == 2);
        }

        [Fact]
        public void ReasignarMesaAReservaEnEspera_ShouldNotAssignTableToWaitList_IfQuantitiesDontMatch()
        {
            var fechaReserva = DateTime.Now;
            var fechaEspera = DateTime.Now;
            for (int i = 1; i <= 18; i++)
            {
                _reservaService.CrearReserva(i, "Diamond", "Federico", DateTime.Now, 2);
            }
            for (int i = 19; i <= 30; i++)
            {
                _reservaService.CrearReserva(i, "Diamond", "Federico", DateTime.Now, 4);
            }
            for (int i = 31; i <= 40; i++)
            {
                _reservaService.CrearReserva(i, "Diamond", "Federico", DateTime.Now, 6);
            }
            //Agrego a lista de espera reserva para 6
            _reservaService.AgregarAListaEspera(2, "Diamond", "Daniel", fechaEspera, 6);
            //Elimino reserva de 4 comensales
            _reservaService.EliminarReserva(30);
            Assert.Single(_reservaService.ObtenerListaEspera());
        }

        [Fact]
        public void CrearReserva_ShouldAllowClassicReservation_When48HoursBefore()
        {
            var fechaReserva = DateTime.Now.AddHours(48);
            var numeroCliente = 1;
            var categoriaClassic = CategoriaConstants.Categorias.FirstOrDefault(c => c.Nombre == "Classic").Nombre;

            var reserva = _reservaService.CrearReserva(numeroCliente, categoriaClassic, "Federico", fechaReserva, 1);

            Assert.NotNull(reserva);
        }

        [Fact]
        public void CrearReserva_ShouldAllowGoldReservation_When72HoursBefore()
        {
            var fechaReserva = DateTime.Now.AddHours(72);
            var numeroCliente = 2;
            var categoriaGold = CategoriaConstants.Categorias.FirstOrDefault(c => c.Nombre == "Gold").Nombre;

            var reserva = _reservaService.CrearReserva(numeroCliente, categoriaGold, "Federico", fechaReserva, 1);

            Assert.NotNull(reserva);
        }

        [Fact]
        public void CrearReserva_ShouldAllowPlatinumReservation_When96HoursBefore()
        {
            var fechaReserva = DateTime.Now.AddHours(96);
            var numeroCliente = 3;
            var categoriaPlatinum= CategoriaConstants.Categorias.FirstOrDefault(c => c.Nombre == "Platinum").Nombre;

            var reserva = _reservaService.CrearReserva(numeroCliente, categoriaPlatinum, "Federico", fechaReserva, 1);

            Assert.NotNull(reserva);
        }

        [Fact]
        public void CrearReserva_ShouldAllowDiamondReservation_WhenAnyTime()
        {
            var fechaReserva = DateTime.Now;
            var numeroCliente = 4;
            var categoriaDiamond = CategoriaConstants.Categorias.FirstOrDefault(c => c.Nombre == "Diamond").Nombre;

            var reserva = _reservaService.CrearReserva(numeroCliente, categoriaDiamond, "Federico", fechaReserva, 1);

            Assert.NotNull(reserva);
        }

        [Fact]
        public void CrearReserva_ShouldNotAllowClassicReservation_WhenLessThan48Hours()
        {
            var fechaReserva = DateTime.Now.AddHours(47);
            var numeroCliente = 5;
            var categoriaClassic = CategoriaConstants.Categorias.FirstOrDefault(c => c.Nombre == "Classic").Nombre;

            var exception = Assert.Throws<CategoriaInvalidaException>(() =>
                _reservaService.CrearReserva(numeroCliente, categoriaClassic, "Federico", fechaReserva, 1)
            );

            Assert.Equal("El cliente no tiene la categoría que corresponde para reservar en la fecha indicada.", exception.Message);
        }

        [Fact]
        public void CrearReserva_ShouldNotAllowGoldReservation_WhenLessThan72Hours()
        {
            var fechaReserva = DateTime.Now.AddHours(71);
            var numeroCliente = 6;
            var categoriaGold = CategoriaConstants.Categorias.FirstOrDefault(c => c.Nombre == "Gold").Nombre;

            var exception = Assert.Throws<CategoriaInvalidaException>(() =>
                _reservaService.CrearReserva(numeroCliente, categoriaGold, "Federico", fechaReserva, 1)
            );

            Assert.Equal("El cliente no tiene la categoría que corresponde para reservar en la fecha indicada.", exception.Message);
        }

        [Fact]
        public void CrearReserva_ShouldNotAllowPlatinumReservation_WhenLessThan96Hours()
        {
            var fechaReserva = DateTime.Now.AddHours(95);
            var numeroCliente = 7;
            var categoriaPlatinum = CategoriaConstants.Categorias.FirstOrDefault(c => c.Nombre == "Platinum").Nombre;

            var exception = Assert.Throws<CategoriaInvalidaException>(() =>
                _reservaService.CrearReserva(numeroCliente, categoriaPlatinum, "Federico", fechaReserva, 1)
            );

            Assert.Equal("El cliente no tiene la categoría que corresponde para reservar en la fecha indicada.", exception.Message);
        }
    }
}
