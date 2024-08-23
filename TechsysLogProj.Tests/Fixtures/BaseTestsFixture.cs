using AutoMapper;
using Bogus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq.AutoMock;
using Moq; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TechsysLogProj.Application.Mappers;
using AutoBogus;
using TechsysLogProj.Application.ViewModel;
using TechsysLogProj.Domain.Entity;

namespace TechsysLogProj.Tests.Fixtures
{
    public class BaseTestsFixture
    {
        public AutoMocker Mocker;
        public IMapper Mapper;
        public static Faker Faker { get; private set; }

        public BaseTestsFixture()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Faker = new Faker("pt_BR");
        }

        protected void SetupMapper()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UsuarioMapper());
                mc.AddProfile(new PedidoMapper());
            });

            Mapper = mappingConfig.CreateMapper();
            Mocker.Use(Mapper); 
        }

        protected void SetupAppSettings()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.test.json", optional: false, reloadOnChange: true)
                .Build();

            Mocker.Use<IConfiguration>(configuration); 
        }

        public  static EnderecoViewModel GerarEnderecoViewModel()
        {
            return new AutoFaker<EnderecoViewModel>()
                .Configure(x =>
                {
                    x.WithTreeDepth(0);
                    x.WithRecursiveDepth(0);
                    x.WithLocale("pt_BR");
                })
                .RuleFor(x => x.Estado, f => "SP")
                .RuleFor(x => x.Cep, f => "00000-000")
                .RuleFor(x => x.Cidade, f => "São Paulo")
                .RuleFor(x => x.Bairro, f => "Centro")
                .RuleFor(x => x.Endereco, f => "Avenida Paulista")
                .RuleFor(x => x.Numero, f => f.Random.Int(5, 2500))
                .Generate();
                
        }

        public static Endereco GerarEnderecoObj()
        {
            return new AutoFaker<Endereco>()
               .Configure(x =>
               {
                   x.WithTreeDepth(0);
                   x.WithRecursiveDepth(0);
                   x.WithLocale("pt_BR");
               })
               .RuleFor(x => x.Estado, f => "SP")
               .RuleFor(x => x.Cep, f => "00000-000")
               .RuleFor(x => x.Cidade, f => "São Paulo")
               .RuleFor(x => x.Bairro, f => "Centro")
               .RuleFor(x => x.Logradouro, f => "Avenida Paulista")
               .RuleFor(x => x.Numero, f => f.Random.Int(5, 2500))
               .Generate();
        }

        public T Map<T>(object source)
        {
            T objetoMapeado = Mapper.Map<T>(source);

            Mocker
                .GetMock<IMapper>()
                .Setup(x => x.Map<T>(source))
                .Returns(objetoMapeado);

            return objetoMapeado;
        }

        public static IList<T> GerarObjeto<T>(int quantidade = 1) where T : class
      => new AutoFaker<T>("pt_BR").Generate(quantidade);
    }
}
