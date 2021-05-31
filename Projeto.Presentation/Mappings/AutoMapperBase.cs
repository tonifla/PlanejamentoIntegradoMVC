using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Projeto.Entities;
using Projeto.Presentation.Models;

namespace Projeto.Presentation.Mappings
{
    public class AutoMapperBase : Profile
    {
        public AutoMapperBase()
        {
            CreateMap<Planejamento, PlanejamentoConsultaPainelViewModel>().ReverseMap();
            CreateMap<Planejamento, PlanejamentoConsultaPIPViewModel>().ReverseMap();

            CreateMap<Programacao, ProgramacaoConsultaViewModel>().ReverseMap();
            CreateMap<Programacao, ProgramacaoEdicaoViewModel>().ReverseMap();
            CreateMap<Programacao, ProgramacaoCadastroViewModel>().ReverseMap();

            CreateMap<Equipe, EquipeConsultaViewModel>().ReverseMap();
            CreateMap<Equipe, EquipeEdicaoViewModel>().ReverseMap();
            CreateMap<Equipe, EquipeCadastroViewModel>().ReverseMap();
        }
    }
}