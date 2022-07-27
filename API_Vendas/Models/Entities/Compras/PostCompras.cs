namespace API_Vendas.Models.Entities.Compras
{
    public class PostCompras
    {
        public int produto_id { get; set; }
        public int qtde_comprada { get; set; }
        public Cartao cartao { get; set; }

        internal bool IsValid(string numero,string cvv)
        {
            if ((numero.Length >= 14 && numero.Length <= 19) && cvv.Length == 3)
            {
                return true;
            }
            return false;
        }
    }
}
