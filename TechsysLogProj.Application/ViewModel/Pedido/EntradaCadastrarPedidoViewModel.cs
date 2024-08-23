using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace TechsysLogProj.Application.ViewModel.Pedido
{
    public class EntradaCadastrarPedidoViewModel
    {       
        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public string CodUsuario { get; set; }

        public int status { get; set; }        

        public EnderecoViewModel EnderecoEntrega { get; set; }  


    }
}
