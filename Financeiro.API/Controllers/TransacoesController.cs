using Financeiro.Application.DTOs;
using Financeiro.Application.Interfaces;
using Financeiro.Application.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Financeiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacoesController : ControllerBase
    {
        private readonly ITransacaoService _transacaoService;
        public TransacoesController(ITransacaoService transacaoService)
        {
            _transacaoService = transacaoService;
        }

        [HttpGet("{ano}/{mes}")]
        public async Task<ActionResult<IEnumerable<TransacaoDTO>>> Get(int mes, int ano, string? tipo, int? id_categoria)
        {
            var categorias = await _transacaoService.GetFilter(mes,ano,tipo, id_categoria);
            return Ok(categorias);
        }

        [HttpGet("{id}", Name = "GetTransacao")]
        public async Task<ActionResult<TransacaoDTO>> Get(int id)
        {
            try
            {
                var transacao = await _transacaoService.GetByID(id);
                return transacao;
            }

            catch (Exception ex) 
            {
                return NotFound(ex.Message);            
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TransacaoDTO transacaoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                transacaoDto = await _transacaoService.Add(transacaoDto);
                return new CreatedAtRouteResult("GetTransacao",
                new { id = transacaoDto.TransacaoID }, transacaoDto);
            }

            catch (Exception )
            {
               return  NotFound("Id categoria não encontrada");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TransacaoDTO transacaoDto)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            if (id != transacaoDto.TransacaoID)
                return BadRequest();

            try 
            {
                await _transacaoService.Update(transacaoDto);
                return Ok(transacaoDto);
            }

            catch
            {
                return NotFound($"Transação com ID {id} não encontrada");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try 
            {
                var transacao = await _transacaoService.GetByID(id);
                await _transacaoService.Remove(id);
                return NoContent();
            }

            catch (Exception ex) 
            {
                return NotFound(ex.Message);
            }
        }
    }
}
