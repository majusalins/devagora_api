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
        public DbSet<Tag> Tag { get; set; }
        public DbSet<Denuncia> Denuncia { get; set; }

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

            modelBuilder.Entity<Post>()
                .HasOne(p => p.Post_Pai)
                .WithMany(p => p.Respostas)
                .HasForeignKey(p => p.Post_Pai_ID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.Usuario_ID_Usuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Denuncias)
                .WithOne(d => d.Usuario)
                .HasForeignKey(d => d.Usuario_ID_Usuario)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Denuncia>()
                .HasOne(p => p.Post)
                .WithMany(p => p.Denuncias)
                .HasForeignKey(p => p.Post_ID_Post)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
