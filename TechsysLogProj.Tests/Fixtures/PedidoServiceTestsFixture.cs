using AutoBogus;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TechsysLogProj.Application.Services;
using TechsysLogProj.Application.ViewModel;
using TechsysLogProj.Application.ViewModel.Pedido;
using TechsysLogProj.Application.ViewModel.Usuario;
using TechsysLogProj.Domain.Entity;

namespace TechsysLogProj.Tests.Fixtures
{
    public class PedidoServiceTestsFixture : BaseTestsFixture
    {
        public EntradaCadastrarPedidoViewModel EntradaViewModel;
        public EntradaCadastrarPedidoViewModel EntradaViewModelInvalida;
        public Pedido PedidoInvalido;
        public Pedido Pedido;

        public PedidoService ObterPedidoService()
        {
            Mocker = new AutoMocker();

            SetupMapper();
            SetupAppSettings();

            EntradaViewModel = GerarEntradaCadastrarPedidoViewModel();

            PedidoInvalido = GerarPedidoInvalido();
            EntradaViewModelInvalida = GerarEntradaCadastrarPedidoViewModelInvalida();

            return Mocker.CreateInstance<PedidoService>();
        }

        public static EntradaCadastrarPedidoViewModel GerarEntradaCadastrarPedidoViewModel()
        {
            return new AutoFaker<EntradaCadastrarPedidoViewModel>("pt_BR")
                .RuleFor(x => x.Descricao, f => "Novo pedido")
                .RuleFor(x => x.Valor, f => f.Random.Decimal(500,10000))
                .RuleFor(x => x.EnderecoEntrega, f => GerarEnderecoViewModel())                
                .Generate();
        }

        public static EntradaCadastrarPedidoViewModel GerarEntradaCadastrarPedidoViewModelInvalida()
        {
            return new AutoFaker<EntradaCadastrarPedidoViewModel>("pt_BR")
                .RuleFor(x => x.Descricao, f => "Novo pedido")
                .RuleFor(x => x.Valor, f => 0 )
                .RuleFor(x => x.EnderecoEntrega, f => GerarEnderecoViewModel())
                .Generate();
        }

        public static Pedido GerarPedidoInvalido()
        {
            return new AutoFaker<Pedido>("pt_BR")
                .RuleFor(x => x.Descricao, f => "Novo pedido")
                .RuleFor(x => x.Valor, f => 0)
                .RuleFor(x => x.EnderecoEntrega, f => GerarEnderecoObj())
                .Generate();
        }


    }
}
