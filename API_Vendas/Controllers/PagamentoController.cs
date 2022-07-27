using API_Vendas.Models.Entities.Loja;
using API_Vendas.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Vendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoRepository repository;
        public PagamentoController(IPagamentoRepository _repository)
        {
            repository = _repository;
        }

        [HttpPost]
        public IActionResult PostPagamento([FromBody]PostPagamento pagamento)
        {   
            if (pagamento is not null)
            {
                var pag = repository.Pagamento(pagamento);
                var respPag = new RespPagamento();
                respPag.valor = pagamento.valor;

                if (pag)
                {
                    respPag.status = "APROVADO";
                }
                else
                {
                    respPag.status = "REPROVADO";
                }
                return Ok(respPag);
            }
            else
            {
                return BadRequest("Ocorreu um erro desconhecido");
            }
        }
    }
}
