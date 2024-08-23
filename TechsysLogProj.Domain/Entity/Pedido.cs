using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechsysLogProj.Domain.Enum;

namespace TechsysLogProj.Domain.Entity
{
    [BsonIgnoreExtraElements]
    public class Pedido
    {
        public string CodPedido { get; set; }
         public string CodUsuario { get; set; }
        public string Descricao { get; set; }   

        public decimal Valor { get; set; }    

        public Endereco EnderecoEntrega { get; set; }
        public EStatusPedido StatusPedido { get; set; }

        public string DescStatus { get
            {
                return ((EStatusPedido)StatusPedido).ToString(); 
            }
            set { } 
        }
        public DateTime? DataEntrega { get; set; }
    }
}
