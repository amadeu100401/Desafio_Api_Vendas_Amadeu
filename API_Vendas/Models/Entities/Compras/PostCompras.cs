namespace API_Vendas.Models.Entities.Compras
{
    public class PostCompras
    {
        public int produto_id { get; set; }
        public int qtde_comprada { get; set; }
        public Cartao cartao { get; set; }

    }
}
