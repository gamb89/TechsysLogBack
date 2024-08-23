using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechsysLogProj.Application.Interfaces;
using TechsysLogProj.Application.ViewModel;
using TechsysLogProj.Application.ViewModel.Pedido;
using TechsysLogProj.Cross.Proxies;
using TechsysLogProj.Domain.Entity;
using TechsysLogProj.Domain.Interfaces;
using TechsysLogProj.Domain.Interfaces.Repositoy;

namespace TechsysLogProj.Application.Services
{
    public class PedidoService : BaseService, IPedidoService
    {
        private readonly IPedidoRepository _repository;
        private readonly ConsultaEnderecoProxy proxy;
        public PedidoService(IMapper mapper, IPedidoRepository repository,IConfiguration configuration) : base(mapper, configuration) 
        {
            _repository = repository;

            proxy = new ConsultaEnderecoProxy(Configuration);
        }

        public async Task<RetornoOperacao> CadastrarPedido(EntradaCadastrarPedidoViewModel entrada)
        {
            if (entrada.Valor == 0)
                return new(false, "O pedido deve ter um valor");
                       

            var pedido = Mapper.Map<Pedido>(entrada);
            pedido.CodPedido = Guid.NewGuid().ToString();           
            pedido.StatusPedido = Domain.Enum.EStatusPedido.EmAnalise;
            await _repository.AddAsync(pedido);
            return new(true,"Pedido cadastrado com sucesso");  
        }

        public async Task<RetornoOperacaoObject<List<RetornoListarPedidoViewModel>>> Listar()
        {
            var pedidos = await _repository.GetAll();

            var retorno = Mapper.Map<List<RetornoListarPedidoViewModel>>(pedidos.ToList()); 
            return new(true, "Pedidos listados com sucesso" , retorno);
        }

    }
}
