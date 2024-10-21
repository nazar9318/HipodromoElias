using HipodromoAPI.Dtos;
using HipodromoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HipodromoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController : ControllerBase
    {
        private readonly ReservaService _reservaService;

        public ReservasController(ReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        [HttpPost]
        public IActionResult CrearReserva([FromBody] ReservaDto reservaDto)
        {
            var reserva = _reservaService.CrearReserva(reservaDto.NumeroCliente, reservaDto.CategoriaCliente, reservaDto.FechaReserva, reservaDto.CantidadPersonas);
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

        [HttpGet]
        public IActionResult ObtenerReservas()
        {
            var reservas = _reservaService.ObtenerReservas();
            return Ok(reservas);
        }

        [HttpGet("lista-espera")]
        public IActionResult ObtenerListaEspera()
        {
            var listaEspera = _reservaService.ObtenerListaEspera();
            return Ok(listaEspera);
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarReserva(int id)
        {
            _reservaService.EliminarReserva(id);
            return NoContent();
        }
    }
}
