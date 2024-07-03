using AutoMapper;
using Financeiro.Application.DTOs;
using Financeiro.Application.Interfaces;
using Financeiro.Domain.Entities;
using Financeiro.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financeiro.Application.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly IMapper _mapper;
        public TransacaoService(ITransacaoRepository transicaoRepository, IMapper mapper)
        {
            _transacaoRepository = transicaoRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TransacaoDTO>> GetTransacoes()
        {
            var transacaoEntity = await _transacaoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TransacaoDTO>>(transacaoEntity);
        }
        public async Task<IEnumerable<TransacaoDTO>> GetFilter(int mes, int ano, string? tipo = null, int? idCategoria = null)
        {
            var transacaoEntity = await _transacaoRepository.GetFilterAsync(mes,ano,tipo, idCategoria);
            return _mapper.Map<IEnumerable<TransacaoDTO>>(transacaoEntity);
        }
        public async Task<TransacaoDTO> GetByID(int id)
        {
            var transacaoEntity = await _transacaoRepository.GetByIdAsync(id);
            return _mapper.Map<TransacaoDTO>(transacaoEntity);
        }
        public async Task<TransacaoDTO> Add(TransacaoDTO transacaoDto)
        {
            var transacaoEntity = _mapper.Map<Transacao>(transacaoDto);
            transacaoEntity = await _transacaoRepository.CreateAsync(transacaoEntity);
            return _mapper.Map<TransacaoDTO>(transacaoEntity);
        }
        public async Task Update(TransacaoDTO transacaoDTO)
        {
            var transacaoEntity = _mapper.Map<Transacao>(transacaoDTO);
            await _transacaoRepository.UpdateAsync(transacaoEntity);
        }
        public async Task Remove(int id)
        {
            var transacaoEntity = _transacaoRepository.GetByIdAsync(id).Result;
            await _transacaoRepository.RemoveAsync(transacaoEntity);
        }
    }
}
