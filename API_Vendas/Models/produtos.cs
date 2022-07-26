using System.ComponentModel.DataAnnotations;

namespace API_Vendas.Models
{
    public class Produtos
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(120)]
        public string Nome { get; set; }
        [Required]
        public double Valor_unitario { get; set; }
        [Required]
        public int Qtde_estoque { get; set; }
    }
}
