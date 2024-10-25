using HipodromoApi.Login;
using HipodromoApi.Services;
using HipodromoAPI.Dtos;
using HipodromoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HipodromoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController : ControllerBase
    {
        private readonly ReservaService _reservaService;
        private readonly ClienteService _clienteService;

        public ReservasController(ClienteService clienteService, ReservaService reservaService)
        {
            _reservaService = reservaService;
            _clienteService = clienteService;
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginRequest request)
        {
            if (!_clienteService.ClienteExiste(request.NumeroCliente, request.NombreLogin))
            {
                return Unauthorized(new { mensaje = "Credenciales incorrectas" });
            }

            return Ok(new { exito = true, mensaje = "Inicio de sesión exitoso", clienteId = _clienteService.Buscar(request.NumeroCliente).NumeroCliente });
        }

        [HttpPost]
        public ActionResult CrearReserva([FromBody] ReservaDto reservaDto)
        {
            var cliente = _clienteService.Buscar(reservaDto.NumeroCliente);
            var reserva = _reservaService.CrearReserva(reservaDto.NumeroCliente, cliente.Categoria, cliente.Nombre, reservaDto.FechaReserva, reservaDto.CantidadPersonas);
            if (reserva.NumeroMesa.HasValue)
            {
                return Ok(new
                {
                    exito = true,
                    mensaje = "Reserva exitosa",
                    numeroMesa = reserva.NumeroMesa
                });
            }
            else
            {
                return Ok(new
                {
                    exito = false,
                    mensaje = "No hay mesas disponibles. ¿Desea agregar su reserva a la lista de espera?",
                    preguntaListaEspera = true
                });
            }
        }

        [HttpPost("lista-espera")]
        public ActionResult AgregarAListaEspera([FromBody] ReservaDto reservaDto)
        {
            var cliente = _clienteService.Buscar(reservaDto.NumeroCliente);
            _reservaService.AgregarAListaEspera(reservaDto.NumeroCliente, cliente.Categoria, cliente.Nombre, reservaDto.FechaReserva, reservaDto.CantidadPersonas);
            return Ok(new
            {
                exito = true,
                mensaje = "Agregado a Lista de Espera"
            });
        }

        [HttpGet]
        public ActionResult ObtenerReservas()
        {
            var reservas = _reservaService.ObtenerReservas();
            return Ok(reservas);
        }

        [HttpGet("lista-espera")]
        public ActionResult ObtenerListaEspera()
        {
            var listaEspera = _reservaService.ObtenerListaEspera();
            return Ok(listaEspera);
        }

        [HttpDelete("{id}")]
        public ActionResult EliminarReserva(int id)
        {
            _reservaService.EliminarReserva(id);
            return Ok(new
            {
                exito = true,
                mensaje = "Reserva eliminada"
            });
        }
    }
}
