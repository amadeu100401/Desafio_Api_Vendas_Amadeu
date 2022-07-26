using API_Vendas.Models;
using API_Vendas.Models.Entities.Produtos;

namespace API_Vendas.Repositories
{
    public interface IProdutosRepository
    {
        public int Create(PostProdutos produtos);
        public List<Produtos> ReadProdutos();
        public Produtos ReadProdId(int id);
        public bool Delete(int Id);
    }

    public class ProdutosRepository: IProdutosRepository
    {
        private readonly _DbContext dataBase;

        public ProdutosRepository(_DbContext _dataBase)
        {
            dataBase = _dataBase;
        }

        #region Metodo POST
        public int Create(PostProdutos produtos)
        {
            try
            {
                if (produtos.Nome is null || produtos.Valor_unitario == 0)
                {
                    return 0;
                }
                else
                {
                    var produtos_db = new Produtos()
                    {
                        Nome = produtos.Nome,
                        Valor_unitario = produtos.Valor_unitario,
                        Qtde_estoque = produtos.Qtde_estoque
                    };
                    dataBase.Estoque.Add(produtos_db);
                    dataBase.SaveChanges();

                    return 1;
                }
            }
            catch
            {
                return 2;
            }
        }
        #endregion

        #region Metodos GET

        public List<Produtos> ReadProdutos()
        {
            var produtos_db = dataBase.Estoque.ToList();
            return produtos_db;
        }

        public Produtos ReadProdId(int Id)
        {
            try
            {
                var produto_db = dataBase.Estoque.Find(Id);
                return produto_db;
            }
            catch
            {
                return new Produtos();
            }
        }
        #endregion

        #region Metodo DELETE
        public bool Delete(int Id)
        {
            try
            {
                var produto_db = dataBase.Estoque.Find(Id);
                if (produto_db is not null)
                {
                    dataBase.Estoque.Remove(produto_db);
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
        #endregion
    }
}
