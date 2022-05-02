

using Microsoft.EntityFrameworkCore;
using StarterBank.Model;

namespace SearchBank.Data
{
    public class SearchBankContext : DbContext
    {
        public DbSet<CaixaEletronico> CaixaEletronico { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) { }

    }
}
