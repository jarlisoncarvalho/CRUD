using Crud.Data.Map;
using Crud.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud.Data
{
    public class SistemasTarefasDbContext : DbContext
    {
        public SistemasTarefasDbContext(DbContextOptions<SistemasTarefasDbContext>options)
            : base(options)
        {   
        }
        public DbSet<UsuarioModel>Usuario { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());


            base.OnModelCreating(modelBuilder); 
        }

    }
}
