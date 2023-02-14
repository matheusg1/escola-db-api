using Microsoft.EntityFrameworkCore;

namespace ApiProjetoEscola.Model.Context
{
    public class ProjetoDbContext : DbContext
    {
        public DbSet<Escola> Escolas { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }

        public ProjetoDbContext()
        {
        }

        public ProjetoDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
