using JovemProgramadorMvc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JovemProgramadorMvc.Data.Mapeamento
{
    public class AlunoMapeamento : IEntityTypeConfiguration<AlunoModel>
    {
        public void Configure(EntityTypeBuilder<AlunoModel> builder)
        {
            builder.ToTable("Alunos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasColumnType("varchar(50)");
            builder.Property(x => x.Contato).HasColumnType("varchar(15)");
            builder.Property(x => x.Email).HasColumnType("varchar(50)");
            builder.Property(x => x.Cep).HasColumnType("varchar(10)");
        }
    }
}
