using Financeiro.Domain.Entities;
using Financeiro.Domain.Interfaces;
using Financeiro.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financeiro.Infrastructure.Repositories
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly ApplicationDbContext _transacaoContext;
        public TransacaoRepository(ApplicationDbContext context)
        {
            _transacaoContext = context;
        }
        public async Task<IEnumerable<Transacao>> GetAllAsync()
        {
            return await _transacaoContext.Transacoes.ToListAsync();
        }
        public async Task<IEnumerable<Transacao>> GetFilterAsync(int mes, int ano, string? tipo = null, int? idCategoria = null)
        {
            var query = _transacaoContext.Transacoes.Include(t => t.Categoria)
                .Where(t => t.DataTransacao.Year == ano && t.DataTransacao.Month == mes);

            if (idCategoria != null)
                query = query.Where(t => t.CategoriaID == idCategoria.Value);

            if (tipo != null)
                query = query.Where(t => t.Categoria.Tipo == tipo);

            var transacao = await query.ToListAsync();

            return transacao;
        }
        public async Task<Transacao> GetByIdAsync(int id)
        {
            var transacao = await _transacaoContext.Transacoes.FindAsync(id);

            if (transacao == null)
                throw new Exception($"Transação com ID {id} não encontrada.");

            return transacao;
        }
        public async Task<Transacao> CreateAsync(Transacao transacao)
        {
            _transacaoContext.Add(transacao);
            await _transacaoContext.SaveChangesAsync();
            return transacao;
        }
        public async Task<Transacao> UpdateAsync(Transacao transacao)
        {
            _transacaoContext.Update(transacao);
            await _transacaoContext.SaveChangesAsync();
            return transacao;
        }
        public async Task<Transacao> RemoveAsync(Transacao transacao)
        {
            _transacaoContext.Remove(transacao);
            await _transacaoContext.SaveChangesAsync();
            return transacao;
        }
    }
}
