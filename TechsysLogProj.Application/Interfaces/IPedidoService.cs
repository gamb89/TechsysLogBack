using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechsysLogProj.Application.ViewModel;
using TechsysLogProj.Application.ViewModel.Pedido;

namespace TechsysLogProj.Application.Interfaces
{
    public interface IPedidoService
    {
        Task<RetornoOperacao> CadastrarPedido(EntradaCadastrarPedidoViewModel pedido);

        Task<RetornoOperacaoObject<List<RetornoListarPedidoViewModel>>> Listar(); 
    }
}
