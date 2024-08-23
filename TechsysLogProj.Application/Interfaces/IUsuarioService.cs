using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechsysLogProj.Application.ViewModel.Pedido;
using TechsysLogProj.Application.ViewModel;
using TechsysLogProj.Application.ViewModel.Usuario;
using TechsysLogProj.Application.ViewModel.Autenticacao;

namespace TechsysLogProj.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<RetornoOperacao> CadastrarUsuario(EntradaCadastrarUsuarioViewModel usuario);

        Task<RetornoOperacaoObject<List<RetornoListarUsuarioViewModel>>> Listar();

        Task<RetornoOperacaoObject<string>> Autenticar(EntradaAutenticacaoViewModel entrada);

        Task<RetornoOperacao> Excluir(string codUsuario);
    }
}
