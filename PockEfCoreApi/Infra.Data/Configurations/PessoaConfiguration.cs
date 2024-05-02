using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PockEfCoreApi.Infra.Data.Tables;

namespace PockEfCoreApi.Infra.Data.Configurations
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {

            builder.ToTable(nameof(Pessoa));

            #region PK

            builder.HasKey(k => k.Id);

            #endregion

            #region Columns

            builder.Property(c => c.Id)
                .HasColumnName(nameof(Pessoa.Id))
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
                .HasColumnName(nameof(Pessoa.Nome))
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(c => c.Nascimento)
                .HasColumnName(nameof(Pessoa.Nascimento))
                .IsRequired();

            #endregion

            #region Indexes

            builder
                .HasIndex(i => i.Nome)
                .HasDatabaseName($"AK_{nameof(Pessoa)}_{nameof(Pessoa.Nome)}")
                .IsUnique();

            #endregion

            #region FKs



            #endregion

        }
    }
}
