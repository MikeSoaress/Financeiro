

using Financeiro.Application.DTOs;

namespace Financeiro.Application.Interfaces
{
    public interface IResumoService
    {
        Task<ResumoDTO> GetResumo(int ano, int mes);
    }
}
