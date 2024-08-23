using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechsysLogProj.Application.ViewModel.Usuario;
using TechsysLogProj.Domain.Entity;

namespace TechsysLogProj.Application.Mappers
{
    public class UsuarioMapper : Profile
    {
        public UsuarioMapper()
        {
            CreateMap<EntradaCadastrarUsuarioViewModel, Usuario>()
                .ForMember(dest => dest.CodUsuario, cfg => cfg.Ignore())
                .ReverseMap();

            CreateMap<RetornoListarUsuarioViewModel, Usuario>()
                .ForMember(dest => dest.Senha, cfg => cfg.Ignore())
                .ReverseMap();

        }
    }
}
