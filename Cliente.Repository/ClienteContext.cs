using System;
using Cliente.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cliente.Repository
{
    public partial class ClienteContext : DbContext
    {
        public ClienteContext()
        {
        }

        public ClienteContext(DbContextOptions<ClienteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClientesEntity> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientesEntity>(entity =>
            {
                entity.HasKey(e => e.ClienteId)
                    .HasName("PK__Clientes__B40CC6CD73B27013");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DataCadastro)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);


            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
