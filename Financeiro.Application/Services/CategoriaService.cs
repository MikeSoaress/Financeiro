using Financeiro.Application.DTOs;
using Financeiro.Application.Interfaces;
using Financeiro.Domain.Interfaces;
using Financeiro.Domain.Entities;
using AutoMapper;
namespace Financeiro.Application.Services;
public class CategoriaService : ICategoriaService
{
    private ICategoriaRespository _categoryRepository;
    private readonly IMapper _mapper;
    public CategoriaService(ICategoriaRespository categoryRepository,
        IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoriaDTO>> GetCategorias()
    {
        var categoriesEntity = await _categoryRepository.GetAllAsync();
        var categoriasDto = _mapper.Map<IEnumerable<CategoriaDTO>>(categoriesEntity);
        return categoriasDto;
    }
    public async Task<CategoriaDTO> GetById(int id)
    {
        var categoryEntity = await _categoryRepository.GetByIdAsync(id);
        return _mapper.Map<CategoriaDTO>(categoryEntity);
    }
    public async Task<CategoriaDTO> Add(CategoriaDTO categoryDto)
    {
        var categoryEntity = _mapper.Map<Categoria>(categoryDto);
        categoryEntity = await _categoryRepository.CreateAsync(categoryEntity);
        return _mapper.Map<CategoriaDTO>(categoryEntity);
    }
    public async Task Update(CategoriaDTO categoryDto)
    {
        var categoryEntity = _mapper.Map<Categoria>(categoryDto);
        await _categoryRepository.UpdateAsync(categoryEntity);
    }
    public async Task Remove(int id)   
    {
        var categoryEntity = _categoryRepository.GetByIdAsync(id).Result;
        await _categoryRepository.RemoveAsync(categoryEntity);
    }

}
