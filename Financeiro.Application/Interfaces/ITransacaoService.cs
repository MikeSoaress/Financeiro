using Financeiro.Application.DTOs;
using Financeiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financeiro.Application.Interfaces
{
    public interface ITransacaoService
    {
        Task<IEnumerable<TransacaoDTO>> GetTransacoes();
        Task<TransacaoDTO> GetByID(int id);

        Task<IEnumerable<TransacaoDTO>> GetFilter(int mes, int ano, string? tipo = null, int? idCategoria = null);

        Task<TransacaoDTO> Add(TransacaoDTO transacaoDTO);
        Task Update(TransacaoDTO transacaoDTO);
        Task Remove(int id);
    }
}
