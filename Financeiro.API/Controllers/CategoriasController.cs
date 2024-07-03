using Financeiro.Application.DTOs;
using Financeiro.Application.Interfaces;
using Financeiro.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Financeiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
        {
            var categorias = await _categoriaService.GetCategorias();
            return Ok(categorias);
        }

        [HttpGet("GetId/{id}", Name = "GetCategoria")]
        public async Task<ActionResult<CategoriaDTO>> Get(int id)
        {
            try
            {
                var categoria = await _categoriaService.GetById(id);
                return Ok(categoria);
            }

            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoriaDTO categoriaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            categoriaDto = await _categoriaService.Add(categoriaDto);

            return new CreatedAtRouteResult("GetCategoria",
                new { id = categoriaDto.CategoriaID }, categoriaDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoriaDTO categoriaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != categoriaDto.CategoriaID)
                return BadRequest("IDs informados são diferentes");

            try
            {
                await _categoriaService.Update(categoriaDto);
                return Ok(categoriaDto);
            }

            catch
            {
                return NotFound("Categoria não encontrada");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var categoriaDto = await _categoriaService.GetById(id);
                await _categoriaService.Remove(id);
                return NoContent();
            }

            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
