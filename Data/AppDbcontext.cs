using Microsoft.EntityFrameworkCore;
using ProjetoAutenticacaoBasica.Api.Models;

namespace ProjetoAutenticacaoBasica.Api.Data
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Passageiro> Passageiros { get; set; }
        public DbSet<Voo> Voos { get; set; }
        public DbSet<Passagem> Passagens { get; set; }
    }
}
