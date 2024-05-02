using Microsoft.EntityFrameworkCore;
using PockEfCoreApi.Infra.Data.Configurations;
using PockEfCoreApi.Infra.Data.Tables;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace PockEfCoreApi.Infra.Data
{
    public class PockDbContext : DbContext
    {

        public PockDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new PessoaConfiguration());
            modelBuilder.ApplyConfiguration(new TipoConfiguration());

            base.OnModelCreating(modelBuilder);
        }


        public virtual DbSet<Pessoa> Pessoas { get; set; }

        public virtual DbSet<Tipo> Tipos { get; set; }

    }
}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
