using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechsysLogProj.Domain.Enum;

namespace TechsysLogProj.Application.ViewModel
{
    public class RetornoOperacao
    {
        public bool Sucesso { get; internal set; }
        public IList<string> Mensagens { get; internal set; }

        public RetornoOperacao()
        {
        }

        public RetornoOperacao(bool sucesso, string mensagem = null)
        {
            Sucesso = sucesso;
            if (mensagem != null)
            {
                AdicionarMensagem(mensagem);
            }
        }

        public RetornoOperacao(bool sucesso, IList<string> mensagens)
        {
            Sucesso = sucesso;
            if (mensagens != null && mensagens.Count > 0)
            {
                AdicionarMensagens(mensagens);
            }
        }

        public void AdicionarMensagens(IList<string> mensagens)
        {
            if (mensagens != null)
            {
                if (Mensagens == null)
                {
                    Mensagens = mensagens;
                }
                else
                {
                    var mensagensAtuais = new List<string>(Mensagens);
                    mensagensAtuais.AddRange(mensagens);
                    Mensagens = mensagensAtuais;
                }
            }
        }

        public void AdicionarMensagem(string mensagem)
        {
            if (Mensagens == null)
            {
                Mensagens = new List<string>();
            }

            var retorno = new List<string>(Mensagens)
              {
                  mensagem
              };

            Mensagens = retorno.ToArray();

        }
    }


}
