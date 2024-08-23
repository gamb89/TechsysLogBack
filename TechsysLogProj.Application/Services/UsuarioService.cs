using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechsysLogProj.Application.Interfaces;
using TechsysLogProj.Application.ViewModel.Pedido;
using TechsysLogProj.Application.ViewModel;
using TechsysLogProj.Domain.Entity;
using TechsysLogProj.Domain.Interfaces.Repositoy;
using TechsysLogProj.Application.ViewModel.Usuario;
using System.Security.Policy;
using TechsysLogProj.Application.ViewModel.Autenticacao;
using TechsysLogProj.Cross.Utils;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace TechsysLogProj.Application.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IMapper mapper, IUsuarioRepository repository,IConfiguration configuration) : base(mapper, configuration)
        {
            _repository = repository;
        }

        public async Task<RetornoOperacao> CadastrarUsuario(EntradaCadastrarUsuarioViewModel entrada)
        {
            var usuario = Mapper.Map<Usuario>(entrada);
            usuario.CodUsuario = Guid.NewGuid().ToString();
            usuario.Senha = Encrypt.Hash(entrada.Senha);   
            await _repository.AddAsync(usuario);
            return new(true,"Usuário cadastrado com sucesso.");
        }

        public async Task<RetornoOperacaoObject<List<RetornoListarUsuarioViewModel>>> Listar()
        {
            var usuarios = await _repository.GetAll();

            var retorno = Mapper.Map<List<RetornoListarUsuarioViewModel>>(usuarios.ToList());
            return new(true, "Usuários listados com sucesso", retorno);
        }

        public async Task<RetornoOperacaoObject<string>> Autenticar(EntradaAutenticacaoViewModel entrada)
        {
            var usuario = await _repository.Autenticar(entrada.UserName);
            if (usuario == null)
                return new(false, "Falha ao autenticar");

            if (!Encrypt.Verify(entrada.Password, usuario.Senha))
                return new(false, "Senha inválida");

            return new(true, "Login realizado com sucesso", GerarToken(usuario));
                
        }

        //Apenas para agilizar, estou deixando esse método aqui, mas não é o correto
        private string GerarToken(Usuario usuario)
        {
            List<Claim> claims = new List<Claim>();
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
               Configuration.GetSection("Secure:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                                   claims: claims,
                                   expires: DateTime.UtcNow.AddDays(1),
                                   signingCredentials: cred
   );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public async Task<RetornoOperacao> Excluir(string codUsuario)
        {
           await  _repository.DeleteOne(x => x.CodUsuario == codUsuario);

            return new(true, "Usuário removido com sucesso");
        }
    }
}
