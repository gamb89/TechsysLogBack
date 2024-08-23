using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechsysLogProj.Domain.Enum
{
    public enum EStatusPedido
    {
        [Description("Em análise")]
        EmAnalise = 1,

        [Description("Pagto Aprovado")]
        Aprovado = 2 ,

        [Description("Cancelado")]
        Cancelado = 3,

        [Description("Em Rota")]
        EmRota = 4 ,

        [Description("Pedido entregue")]
        Entregue = 5
    }
}
