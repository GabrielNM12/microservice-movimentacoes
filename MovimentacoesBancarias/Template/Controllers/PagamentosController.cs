using Microsoft.AspNetCore.Mvc;

namespace Pagamentos
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagamentosController : ControllerBase
    {
        private readonly IServPagamento _servPagamento;

        public PagamentosController()
        {
            _servPagamento = new ServPagamento();
        }

        [HttpPost]
        [Route("registrar")]
        public IActionResult RegistrarPagamento([FromBody] RegistrarPagamentoDTO pagamentoDto)
        {
            try
            {
                _servPagamento.RegistrarPagamento(pagamentoDto);

                return Ok(new
                {
                    Mensagem = "Pagamento registrado com sucesso."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Mensagem = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult BuscarPagamentos()
        {
            try
            {
                var pagamentos = _servPagamento.BuscarPagamentos();

                return Ok(pagamentos);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Mensagem = ex.Message
                });
            }
        }
    }
}