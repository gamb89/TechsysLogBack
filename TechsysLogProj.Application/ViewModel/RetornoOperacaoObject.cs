using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechsysLogProj.Application.ViewModel
{
    public class RetornoOperacaoObject<ViewModel> : RetornoOperacao
    {
        public ViewModel Entidade { get; internal set; }

        public RetornoOperacaoObject(RetornoOperacao retornoOperacao)
            : base(retornoOperacao?.Sucesso ?? false, retornoOperacao?.Mensagens)
        { }

        public RetornoOperacaoObject(bool sucesso, string mensagem, ViewModel entidadeRetorno = default)
            : base(sucesso, mensagem)
        {
            Entidade = entidadeRetorno;
        }

        public RetornoOperacaoObject(bool sucesso, IList<string> mensagens, ViewModel entidadeRetorno = default)
            : base(sucesso, mensagens)
        {
            Entidade = entidadeRetorno;
        }
    }
}
