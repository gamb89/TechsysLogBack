using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TechsysLogProj.Application.ViewModel;
using TechsysLogProj.Application.ViewModel.Pedido;
using TechsysLogProj.Domain.Entity;

namespace TechsysLogProj.Application.Mappers
{
    public  class PedidoMapper : Profile
    {
       
        public PedidoMapper() 
        {
            CreateMap<EntradaCadastrarPedidoViewModel, Pedido>()
                .ForMember(dest => dest.StatusPedido, cfg => cfg.Ignore())
                .ForMember(dest => dest.DataEntrega, cfg => cfg.Ignore())
                .ReverseMap();

            CreateMap<EnderecoViewModel, Endereco>()
                .ForMember(dest => dest.Logradouro, cfg => cfg.MapFrom(src => src.Endereco)).ReverseMap();

            CreateMap<RetornoListarPedidoViewModel, Pedido>()
                 .ForMember(dest => dest.StatusPedido, cfg => cfg.Ignore())
                 .ReverseMap();


        }
    }
}
