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
    public class CategoriasController : ControllerBase
    {
        private readonly CategoriaService _categoriaService;

        public CategoriasController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public ActionResult<List<Categoria>> ObtenerMesasDisponibles()
        {
            return _categoriaService.ObtenerCategorias();
        }
    }
}
