using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechsysLogProj;
using TechsysLogProj.API;
using TechsysLogProj.API.Controllers;
using TechsysLogProj.API.Controllers.v1;
using TechsysLogProj.Application.Interfaces;
using TechsysLogProj.Application.ViewModel;
using TechsysLogProj.Application.ViewModel.Autenticacao;

namespace TechsysLogProj.API.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public AutenticacaoController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<RetornoOperacaoObject<string>>> Autenticar([FromBody] EntradaAutenticacaoViewModel entrada)
            => Ok(await _service.Autenticar(entrada));
            
    }
}
