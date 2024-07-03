using AutoMapper;
using Financeiro.Application.DTOs;
using Financeiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financeiro.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Transacao, TransacaoDTO>().ReverseMap();
            CreateMap<Resumo, ResumoDTO>().ReverseMap();
        }
    }
}
