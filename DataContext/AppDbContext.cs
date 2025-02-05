using Microsoft.EntityFrameworkCore;
using ProjetoPABD.Models;

namespace ProjetoPABD.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Rascunho> Rascunho { get; set; }
        public DbSet<Post> Post { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Perfil)
                .WithOne(p => p.Usuario)
                .HasForeignKey<Perfil>(p => p.Usuario_ID_Usuario)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Rascunhos)
                .WithOne(r => r.Usuario)
                .HasForeignKey(r => r.Usuario_ID_Usuario)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Posts)
                .WithOne(post => post.Usuario)
                .HasForeignKey(post => post.Usuario_ID_Usuario)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
