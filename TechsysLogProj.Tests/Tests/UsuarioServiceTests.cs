using Moq;
using Moq.AutoMock;
using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechsysLogProj.Application.Interfaces;
using TechsysLogProj.Application.Services;
using TechsysLogProj.Application.ViewModel;
using TechsysLogProj.Domain.Entity;
using TechsysLogProj.Domain.Interfaces;
using TechsysLogProj.Domain.Interfaces.Repositoy;
using TechsysLogProj.Tests.Fixtures;

namespace TechsysLogProj.Tests.Tests
{
    public class UsuarioServiceTests : IClassFixture<UsuarioServiceTestsFixture>
    {
        protected readonly UsuarioServiceTestsFixture Fixture;
        protected readonly UsuarioService Service; 

        public UsuarioServiceTests(UsuarioServiceTestsFixture fixture)
        {
            Fixture = fixture;
            Service = fixture.ObterUsuarioService(); 
        }

        #region ADD
        [Fact(DisplayName = "Criar um novo usuário com sucesso")]
        [Trait("Service","UsuarioService")]
        public async Task Criar_ComEntradaValida_DeveRetornarSucesso()
        {
            const string MensagemEsperada = "Usuário cadastrado com sucesso.";

            Fixture.Mocker
                .GetMock<IUsuarioRepository>()
                .Setup(s => s.AddAsync(It.IsAny<Usuario>()));


            var retorno = await Service.CadastrarUsuario(Fixture.EntradaViewModel);

            Fixture.Mocker.GetMock<IUsuarioRepository>().Verify(x => x.AddAsync(It.IsAny<Usuario>()),Times.Once());

            Assert.NotNull(retorno);
            Assert.True(retorno.Sucesso);
            Assert.Single(retorno.Mensagens);
            Assert.All(retorno.Mensagens, item => Assert.Equal(MensagemEsperada, item));
            
        }

        #endregion

        #region List/Search

        [Fact(DisplayName = "Listar Usuários")]
        [Trait("Service", "UsuarioService")]
        public async Task Usuario_Listar_DeveRetornarSucesso()
        {
            const string MensagemEsperada = "Usuários listados com sucesso";

            var usuarios = Fixture.GerarRetornoUsuarios(2);

            Fixture.Mocker
                .GetMock<IUsuarioRepository>()
                .Setup(s => s.GetAll())
                .ReturnsAsync(usuarios);

            var retorno = await Service.Listar();

            Fixture.Mocker.GetMock<IUsuarioRepository>().Verify(v => v.GetAll(), Times.Once);
            Assert.NotNull(retorno);
            Assert.True(retorno.Sucesso);
            Assert.All(retorno.Mensagens, item => Assert.Equal(MensagemEsperada, item));    
        }
        #endregion
    }
}
