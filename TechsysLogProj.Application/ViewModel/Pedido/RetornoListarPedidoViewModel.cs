using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechsysLogProj.Application.ViewModel.Pedido
{
    public class RetornoListarPedidoViewModel
    {
        public string CodPedido { get; set; }

        public string CodUsuario { get; set; }

        public string Descricao { get; set; }   

        public decimal Valor { get; set; }

        public EnderecoViewModel EnderecoEntrega { get; set; }

        public string StatusPedido { get; set; }    

        public DateTime? DataEntrega { get;  set; }
    }
}
