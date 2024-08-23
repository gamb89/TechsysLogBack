using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechsysLogProj.Application.Services;
using TechsysLogProj.Domain.Entity;
using TechsysLogProj.Domain.Interfaces.Repositoy;
using TechsysLogProj.Tests.Fixtures;

namespace TechsysLogProj.Tests.Tests
{
    public class PedidoServiceTests : IClassFixture<PedidoServiceTestsFixture>
    {
        protected readonly PedidoServiceTestsFixture Fixture;
        protected readonly PedidoService Service;

        public PedidoServiceTests (PedidoServiceTestsFixture fixture)
        {
            Fixture = fixture;
            Service = Fixture.ObterPedidoService();
        }

        #region Add
        [Fact(DisplayName = "Criar um novo pedido com sucesso")]
        [Trait("Service", "PedidoService")]
        public async Task Criar_ComEntradaValida_DeveRetornarSucesso()
        {
            const string MensagemEsperada = "Pedido cadastrado com sucesso";

            Fixture.Mocker
                .GetMock<IPedidoRepository>()
                .Setup(s => s.AddAsync(It.IsAny<Pedido>()));

            var retorno = await Service.CadastrarPedido(Fixture.EntradaViewModel);

            Fixture.Mocker.GetMock<IPedidoRepository>().Verify(x => x.AddAsync(It.IsAny<Pedido>()), Times.Once());

            Assert.NotNull(retorno);
            Assert.True(retorno.Sucesso);
            Assert.Single(retorno.Mensagens);
            Assert.All(retorno.Mensagens, item => Assert.Equal(MensagemEsperada, item));
        }

        [Fact(DisplayName = "Falhar ao criar um novo pedido com valor 0 ")]
        [Trait("Service", "PedidoService")]
        public async Task Criar_ComValorInvalido_DeveRetornarFalha()
        {
            const string MensagemEsperada = "O pedido deve ter um valor";

            Fixture.Mocker
                .GetMock<IPedidoRepository>()
                .Setup(s => s.AddAsync(Fixture.PedidoInvalido));

            var retorno = await Service.CadastrarPedido(Fixture.EntradaViewModelInvalida);

            Fixture.Mocker.GetMock<IPedidoRepository>().Verify(x => x.AddAsync(Fixture.Pedido), Times.Never());

            Assert.NotNull(retorno);
            Assert.False(retorno.Sucesso);
            Assert.Single(retorno.Mensagens);
            Assert.All(retorno.Mensagens, item => Assert.Equal(MensagemEsperada, item));
        }


        #endregion
    }
}
