using Fiap.Web.Alunos.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Alunos.Data
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<RepresentanteModel> Representantes { get; set; }
        public virtual DbSet<ClienteModel> Clientes { get; set; }
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RepresentanteModel>(entity =>
            {
                entity.ToTable("REPRESENTANTES"); // Nome da tabela em maiúsculas
                entity.HasKey(e => e.RepresentanteId);
                entity.Property(e => e.RepresentanteId).HasColumnName("REPRESENTANTEID"); // Nome da coluna em maiúsculas
                entity.Property(e => e.RepresentanteNome).HasColumnName("REPRESENTANTENOME").IsRequired(); // Nome da coluna em maiúsculas
                entity.Property(e => e.Cpf).HasColumnName("CPF"); // Nome da coluna em maiúsculas
                entity.HasIndex(e => e.Cpf).IsUnique();
            });

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClienteModel>(entity =>
            {
                // Define o nome da tabela para 'Clientes'
                entity.ToTable("Clientes");
                entity.HasKey(e => e.ClienteId);
                entity.Property(e => e.Nome).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.DataNascimento).HasColumnType("date");
                entity.Property(e => e.Observacao).HasMaxLength(500);

                entity.HasOne(e => e.Representante)
                .WithMany()
                .HasForeignKey(e => e.RepresentanteId)
                .IsRequired();
            });
        }
    }
}