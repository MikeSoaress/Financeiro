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

namespace Financeiro.Application.Services;

public class ResumoService : IResumoService
{
    private readonly ITransacaoRepository _transacaoRepository;
    private readonly IMapper _mapper;
    public ResumoService(ITransacaoRepository transacaoRepository, IMapper mapper)
    {
        _transacaoRepository = transacaoRepository;
        _mapper = mapper;
    }
    public async Task<ResumoDTO> GetResumo(int mes, int ano)
    {
        var transacoes = await _transacaoRepository.GetFilterAsync(mes, ano);

        ResumoDTO resumoDto = new ResumoDTO { ano = ano, mes = mes };

        foreach (var t in transacoes)
        {
            if (t.Categoria.Tipo == "entrada")
                resumoDto.total_entradas += t.Valor;

            else if (t.Categoria.Tipo == "saida")
                resumoDto.total_saidas += t.Valor;
        }

        resumoDto.dre = resumoDto.total_entradas - resumoDto.total_saidas;
        return resumoDto;
    }
}
