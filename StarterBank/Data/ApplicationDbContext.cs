﻿

using Microsoft.EntityFrameworkCore;
using StarterBank.Model;

namespace StarterBank.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CaixaEletronico> CaixaEletronico { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder){}
    }
}
