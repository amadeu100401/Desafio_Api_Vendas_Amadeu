using API_Vendas.Models.Entities.Produtos;
using API_Vendas.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Vendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutosRepository repository;
        public ProdutosController(IProdutosRepository _repository)
        {
            repository = _repository;
        }

        #region Endpoint POST
        [HttpPost]
        public IActionResult Post([FromBody] PostProdutos produtos)
        {
            if (repository.Create(produtos) == 1)
            {
                return Ok("Produto Cadastrado");
            }
            else if (repository.Create(produtos) == 0)
            {
                return ValidationProblem("Os valores informados não são válidos");
            }
            return BadRequest("Ocorreu um erro desconhecido");
        }
        #endregion

        #region Endpoints GET
        [HttpGet]
        public IActionResult GetProdutos()
        {
            var produtos_db = repository.ReadProdutos();
            return Ok(produtos_db);    
        }

        [HttpGet("{Id}")]
        public IActionResult GetProduto([FromRoute]ProdutoId produto)
        {
            var produto_db = repository.ReadProdId(produto.Id);
            if (produto_db is not null)
            {
                return Ok(produto_db);
            }
            else
            {
                return BadRequest("Ocorreu um erro desconhecido");
            }
        }
        #endregion

        #region Endpoint DELETE
        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute]ProdutoId produto)
        {
            var produto_db = repository.Delete(produto.Id);
            if (produto_db)
            {
                return Ok("Produto excluido com sucesso");
            }
            else
            {
                return BadRequest("Ocorreu um erro desconhecido");
            }
        }
        #endregion

    }
}
