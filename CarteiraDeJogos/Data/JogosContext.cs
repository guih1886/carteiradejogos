using CarteiraDeJogos.Models;
using Microsoft.EntityFrameworkCore;

namespace CarteiraDeJogos.Data
{
    public class JogosContext: DbContext
    {
        public JogosContext(DbContextOptions<JogosContext> opts)
        : base(opts)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jogos>().HasKey(jogos => jogos.Id);
        }

        public DbSet<Jogos> Jogos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
