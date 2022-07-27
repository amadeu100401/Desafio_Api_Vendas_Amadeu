using API_Vendas.Models;
using API_Vendas.Models.Entities.Loja;

namespace API_Vendas.Repositories
{
    public interface IPagamentoRepository
    {
        public bool Pagamento(PostPagamento pagamento);
    }
    public class PagamentoRepository: IPagamentoRepository
    {
        public bool Pagamento(PostPagamento pagamento)
        {
            try
            {
                var respPag = new RespPagamento();
                if (pagamento.cartao.IsValid(pagamento.cartao.numero,pagamento.cartao.cvv) && pagamento.valor > 100)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
