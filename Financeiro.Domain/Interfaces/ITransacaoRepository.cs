using Financeiro.Domain.Entities;

namespace Financeiro.Domain.Interfaces;

public interface ITransacaoRepository : IRepositoryBase<Transacao>
{
    Task<IEnumerable<Transacao>> GetFilterAsync(int mes, int ano, string? tipo = null, int? idCategoria = null);
}
