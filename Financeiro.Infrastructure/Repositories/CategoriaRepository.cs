using Financeiro.Domain.Entities;
using Financeiro.Domain.Interfaces;
using Financeiro.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Financeiro.Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRespository
    {
        private ApplicationDbContext _categoryContext;
        public CategoriaRepository(ApplicationDbContext context)
        {
            _categoryContext = context;
        }
        public async Task<IEnumerable<Categoria>> GetAllAsync()
        {
            var categorias = await _categoryContext.Categorias.ToListAsync();
            return categorias;
        }
        public async Task<Categoria> GetByIdAsync(int id)
        {
            var categoria = await _categoryContext.Categorias.FindAsync(id);

            if (categoria == null)
                throw new Exception($"Categoria com ID {id} não encontrada.");

            return categoria;
        }
        public async Task<Categoria> CreateAsync(Categoria categoria)
        {
            _categoryContext.Add(categoria);
            await _categoryContext.SaveChangesAsync();
            return categoria;
        }
        public async Task<Categoria> UpdateAsync(Categoria categoria)
        {
            _categoryContext.Update(categoria);
            await _categoryContext.SaveChangesAsync();
            return categoria;
        }
        public async Task<Categoria> RemoveAsync(Categoria categoria)
        {
            _categoryContext.Remove(categoria);
            await _categoryContext.SaveChangesAsync();
            return categoria;
        }
    }
}
