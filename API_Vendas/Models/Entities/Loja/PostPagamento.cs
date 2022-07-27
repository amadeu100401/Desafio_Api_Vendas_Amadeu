using API_Vendas.Models.Entities.Compras;

namespace API_Vendas.Models.Entities.Loja
{
    public class PostPagamento
    {
        public double valor { get; set; }
        public Cartao cartao { get; set; }
    }
}
    