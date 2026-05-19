using Microsoft.EntityFrameworkCore;
using MovimentacoesBancarias.Servicos;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Exemplo
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //public DbSet<Exemplo> Exemplos { get; set; }
        public DbSet<Movimentos> Movimentos{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Exemplo>().HasKey(p => p.Id);
            modelBuilder.Entity<Movimentos>().HasKey(p => p.Id);


            base.OnModelCreating(modelBuilder);
        }
    }
}
