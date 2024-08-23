using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechsysLogProj.Domain.Enum
{
    public enum ETipoMensagemRetorno
    {
        [Description("INF")]
        Informacao,
        [Description("ERG")]
        ErroGenerico,
        [Description("ERB")]
        ErroBanco
    }
}
