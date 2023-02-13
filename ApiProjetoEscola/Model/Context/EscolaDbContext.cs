using Microsoft.EntityFrameworkCore;

namespace ApiProjetoEscola.Model.Context
{
    public class EscolaDbContext : DbContext
    {
        public DbSet<Escola> Escolas { get; set; }

        public EscolaDbContext()
        {
        }

        public EscolaDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
