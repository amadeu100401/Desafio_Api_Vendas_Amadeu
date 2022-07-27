using API_Vendas.Models;
using API_Vendas.Models.Entities.Compras;
using System.ComponentModel.DataAnnotations;

namespace API_Vendas.Repositories
{
    public interface IComprasRepository
    {
        public bool Comprar(PostCompras compra);
    }
    public class ComprasRepository: IComprasRepository
    {
        private readonly _DbContext dataBase;

        public ComprasRepository(_DbContext _dataBase)
        {
            dataBase = _dataBase;
        }
        public bool Comprar(PostCompras compra)
        {
            try
            {
                var attribute = new CreditCardAttribute();
                var produto_db = dataBase.Estoque.Find(compra.produto_id);
                if (produto_db != null && produto_db.Qtde_estoque >= compra.qtde_comprada)
                {
                    produto_db.Qtde_estoque = produto_db.Qtde_estoque - compra.qtde_comprada;
                    dataBase.SaveChanges();
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
