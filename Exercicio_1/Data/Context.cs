using Exercicio_1.Models;
using Microsoft.EntityFrameworkCore;


namespace Exercicio_1.Data
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options): base(options){}

        public DbSet<Curso> Curso { get; set; }
        public DbSet<Sala> Sala { get; set; }
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Atendimento> Atendimento { get; set; }
    }
}
