namespace API_Vendas.Models.Entities.Compras
{
    public class Cartao
    {
        public string titular { get; set; }
        public string numero { get; set; }
        public string data_expedicao { get; set; }
        public string bandeira { get; set; }
        public string cvv { get; set; }
    }
}