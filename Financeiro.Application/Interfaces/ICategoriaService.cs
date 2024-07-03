using Financeiro.Application.DTOs;

namespace Financeiro.Application.Interfaces;

public interface ICategoriaService
{
    Task<IEnumerable<CategoriaDTO>> GetCategorias();
    Task<CategoriaDTO> GetById(int id);
    Task<CategoriaDTO> Add (CategoriaDTO categoriaDto);
    Task Update(CategoriaDTO categoriaDto);
    Task Remove(int id);
}
