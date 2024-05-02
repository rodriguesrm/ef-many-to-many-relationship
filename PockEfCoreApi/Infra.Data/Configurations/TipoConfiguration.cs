using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PockEfCoreApi.Infra.Data.Tables;

namespace PockEfCoreApi.Infra.Data.Configurations
{
    public class TipoConfiguration : IEntityTypeConfiguration<Tipo>
    {
        public void Configure(EntityTypeBuilder<Tipo> builder)
        {

            builder.ToTable(nameof(Tipo));

            #region PK

            builder.HasKey(k => k.Id);

            #endregion

            #region Columns

            builder.Property(c => c.Id)
                .HasColumnName(nameof(Tipo.Id))
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
                .HasColumnName(nameof(Tipo.Nome))
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            #endregion

            #region Indexes

            builder
                .HasIndex(i => i.Nome)
                .HasDatabaseName($"AK_{nameof(Tipo)}_{nameof(Tipo.Nome)}")
                .IsUnique();

            #endregion

            #region FKs

            builder
                .HasMany(p => p.Pessoas)
                .WithMany(t => t.Tipos)
                .UsingEntity<PessoaTipo>(
                    $"{nameof(PessoaTipo)}",
                    tb1 => tb1
                        .HasOne(c => c.Pessoa)
                        .WithMany()
                        .HasForeignKey(fk => fk.PessoaId),
                    tb2 => tb2
                        .HasOne(t => t.Tipo)
                        .WithMany()
                        .HasForeignKey(fk => fk.TipoId)
                );

            #endregion

        }
    }
}
