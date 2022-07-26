using System.ComponentModel.DataAnnotations;

namespace API_Vendas.Models.Entities.Produtos
{
    public class PostProdutos
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public double Valor_unitario { get; set; }
        [Required]
        public int Qtde_estoque { get; set; }
    }
}
