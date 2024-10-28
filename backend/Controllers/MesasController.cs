using HipodromoApi.Login;
using HipodromoApi.Services;
using HipodromoAPI.Dtos;
using HipodromoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HipodromoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MesasController : ControllerBase
    {
        private readonly ReservaService _reservaService;
        private readonly MesaService _mesaService;

        public MesasController(MesaService mesaService, ReservaService reservaService)
        {
            _reservaService = reservaService;
            _mesaService = mesaService;
        }

        [HttpGet("disponibles")]
        public ActionResult<List<Mesa>> ObtenerMesasDisponibles(DateTime? fecha = null)
        {
            var mesasDisponibles = _mesaService.ObtenerMesas();
            var reservas = _reservaService.ObtenerReservas();

            var mesasConDisponibilidad = mesasDisponibles.Select(mesa =>
            {
                int personasReservadas = 0;

                if (fecha.HasValue)
                {
                    personasReservadas = reservas
                        .Where(r => r.NumeroMesa == mesa.NumeroMesa && r.FechaReserva.Date == fecha.Value.Date)
                        .Sum(r => r.CantidadPersonas);
                }

                return new
                {
                    mesa.NumeroMesa,
                    CapacidadTotal = mesa.Cubiertos,
                    PersonasOcupando = personasReservadas
                };
            }).ToList();

            return Ok(mesasConDisponibilidad);
        }
    }
}
