using Microsoft.AspNetCore.Mvc;
using TechsysLogProj.Application.Interfaces;
using TechsysLogProj.Application.ViewModel;
using TechsysLogProj.Application.ViewModel.Pedido;
using TechsysLogProj.Application.ViewModel.Usuario;

namespace TechsysLogProj.API.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _service;
        public PedidoController(IPedidoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<RetornoOperacao>> CadastrarPedido([FromBody] EntradaCadastrarPedidoViewModel entrada)
            => Ok(await _service.CadastrarPedido(entrada));

        [HttpGet("list")]
        public async Task<ActionResult<RetornoOperacaoObject<List<RetornoListarPedidoViewModel>>>> Listar()
        {
            var pedidos = await _service.Listar();
            return Ok(pedidos);
        }
    }
}
