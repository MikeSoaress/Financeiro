using Financeiro.Application.DTOs;
using Financeiro.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Financeiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumoController : ControllerBase
    {
        private readonly IResumoService _resumoService;
        public ResumoController(IResumoService resumoService)
        {
            _resumoService = resumoService;
        }

        [HttpGet("{ano}/{mes}")]
        public async Task<ActionResult<ResumoDTO>> Get(int mes, int ano)
        {
            var resumo = await _resumoService.GetResumo(mes, ano);
            return Ok(resumo);
        }
    }
}
