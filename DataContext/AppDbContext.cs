using Microsoft.EntityFrameworkCore;
using ProjetoPABD.Models;

namespace ProjetoPABD.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
    }
}

