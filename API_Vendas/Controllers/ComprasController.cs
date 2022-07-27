using API_Vendas.Models;
using API_Vendas.Models.Entities.Compras;
using API_Vendas.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API_Vendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly IComprasRepository repository;
        public ComprasController(IComprasRepository _repository)
        {
            repository = _repository;
        }

        [HttpPost]
        public IActionResult PostCompra([FromBody]PostCompras compra)
        {
            if (compra.cartao.IsValid(compra.cartao.numero,compra.cartao.cvv))
            {
                if (repository.Comprar(compra))
                    return Ok("Venda realizada com sucesso");
                else
                    return BadRequest("Ocorrue um erro desconhecido");
            }
            else
            {
                return BadRequest("Os valores informados não são válidos");
            }
        }   
    }
}
