using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechsysLogProj.Application.Interfaces;
using TechsysLogProj.Application.ViewModel.Pedido;
using TechsysLogProj.Application.ViewModel;
using TechsysLogProj.Application.ViewModel.Usuario;

namespace TechsysLogProj.API.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<RetornoOperacao>> CadastrarUsuario([FromBody] EntradaCadastrarUsuarioViewModel entrada)
            => Ok(await _service.CadastrarUsuario(entrada));

        [HttpGet("list")]
        public async Task<ActionResult<RetornoOperacaoObject<RetornoListarUsuarioViewModel>>> Listar()
        {
            var usuarios = await _service.Listar();

            return Ok(usuarios);
        }

        [HttpDelete("{codUsuario}")]
        public async Task<ActionResult<RetornoOperacao>> Delete([FromRoute] string codUsuario)
        {
            return Ok(await _service.Excluir(codUsuario));


        }
    }
}
