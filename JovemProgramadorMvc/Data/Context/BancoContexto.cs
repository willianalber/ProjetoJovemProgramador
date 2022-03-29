using System.Reflection;
using JovemProgramadorMvc.Data.Mapeamento;
using JovemProgramadorMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace JovemProgramadorMvc.Data.Context
{
    public class BancoContexto : DbContext
    {
        public BancoContexto(DbContextOptions<BancoContexto> optionsBuilder) : base(optionsBuilder)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("DefaultConnection");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMapeamento());
            //base.OnModelCreating(modelBuilder);

            //Assembly assemblyWithConfigurations = GetType().Assembly;
            //modelBuilder.ApplyConfigurationsFromAssembly(assemblyWithConfigurations);
        }

        public DbSet<AlunoModel> Aluno { get; set; }
    }
}
