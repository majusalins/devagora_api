using Microsoft.EntityFrameworkCore;
using ProjetoPABD.Models;

namespace ProjetoPABD.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Perfil> Perfil { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da relação 1:1 entre Usuario e Perfil
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Perfil)
                .WithOne(p => p.Usuario)
                .HasForeignKey<Perfil>(p => p.Usuario_ID_Usuario) // Define a chave estrangeira na tabela Perfil
                .OnDelete(DeleteBehavior.Cascade); // Se um usuário for excluído, o perfil também será excluído

            base.OnModelCreating(modelBuilder);
        }
    }
}
