using Microsoft.AspNetCore.Mvc;
using MovimentacoesBancarias.Servicos;

namespace MovimentacoesBancarias
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentosController : Controller
    {
        private ServMovimentos _servMovimentos;

        public MovimentosController()
        {
            _servMovimentos = new ServMovimentos();
        }

        [HttpPost("entrada")]
        public IActionResult RegistrarEntrada([FromBody] RegistrarMovimentosDTO movimentosDto)
        {
            try
            {
                if (movimentosDto == null)
                {
                    return BadRequest("Dados inválidos");
                }

                _servMovimentos.RegistrarEntradas(movimentosDto);
                return Created("Entrada registrada com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("saida")]
        public IActionResult RegistrarSaidas([FromBody] RegistrarMovimentosDTO movimentosDto)
        {
            try
            {
                if (movimentosDto == null)
                {
                    return BadRequest("Dados inválidos");
                }

                _servMovimentos.RegistrarSaidas(movimentosDto);
                return Created("Saida registrada com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("movimentacoes")]
        public IActionResult BuscarMovimentacoes()
        {
            try
            {
                List<Movimentos> movimentacoes = _servMovimentos.BuscarMovimentacoes();
                return Ok(movimentacoes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
