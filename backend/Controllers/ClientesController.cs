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
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClientesController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public ActionResult<List<Cliente>> ObtenerClientes()
        {
            var clientes = _clienteService.ObtenerClientes().Select(c =>
                {
                    return new Cliente
                    {
                        Nombre = c.Nombre,
                        NumeroCliente = -1,
                        Categoria = c.Categoria
                    };
                }                
            ).ToList();
            return clientes;
        }
    }
}
