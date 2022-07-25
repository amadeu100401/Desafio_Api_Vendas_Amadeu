using Microsoft.EntityFrameworkCore;

namespace API_Vendas.Models
{
    public class _DbContext:DbContext
    {
        public _DbContext(DbContextOptions<_DbContext> option) : base(option) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<EstoqueProdutos> Estoque { get; set; }
    }
}
