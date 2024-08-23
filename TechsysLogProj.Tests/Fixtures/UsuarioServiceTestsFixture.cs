using AutoBogus;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechsysLogProj.Application.Services;
using TechsysLogProj.Application.ViewModel.Usuario;
using TechsysLogProj.Domain.Entity;
using TechsysLogProj.Domain.Interfaces.Repositoy;

namespace TechsysLogProj.Tests.Fixtures
{
    public class UsuarioServiceTestsFixture : BaseTestsFixture
    {
        public EntradaCadastrarUsuarioViewModel EntradaViewModel;
        public Usuario Usuario; 

        public UsuarioService ObterUsuarioService()
        {
            Mocker = new AutoMocker();

            SetupMapper();
            SetupAppSettings();

            EntradaViewModel = GerarEntradaCadastroUsuarioViewModel();

            return Mocker.CreateInstance<UsuarioService>(); 
        }

        public  List<Usuario> GerarRetornoUsuarios(int quantidade)
        {
            return new AutoFaker<Usuario>()
                .Configure(x =>
                {
                    x.WithTreeDepth(0);
                    x.WithRecursiveDepth(0);
                    x.WithLocale("pt_BR");
                })
                .RuleFor(x => x.CodUsuario, (f, c) => Guid.NewGuid().ToString())
                .RuleFor(x => x.Nome, f => f.Person.FirstName)
                .RuleFor(x => x.Email, (f, c) => f.Internet.Email("teste", "teste", null, null))
                .Generate(quantidade);                 
                
        }

        public static EntradaCadastrarUsuarioViewModel GerarEntradaCadastroUsuarioViewModel()
        {
            return new AutoFaker<EntradaCadastrarUsuarioViewModel>("pt_BR")
                .RuleFor(x => x.Email, (f, c) => f.Person.Email)
                .RuleFor(x => x.Senha, (f, c) => "1234")
                .RuleFor(x => x.Nome, f => f.Person.FirstName)
                .Generate(); 
        }


    }
}
