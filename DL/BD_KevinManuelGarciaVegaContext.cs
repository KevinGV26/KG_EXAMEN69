using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DL
{
    public partial class BD_KevinManuelGarciaVegaContext : DbContext
    {
        public BD_KevinManuelGarciaVegaContext()
        {
        }

        public BD_KevinManuelGarciaVegaContext(DbContextOptions<BD_KevinManuelGarciaVegaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fabricante> Fabricantes { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-6OBJBAUI; Database= BD_KevinManuelGarciaVega; Trusted_Connection=True; User ID=sa; Password=pass@word1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fabricante>(entity =>
            {
                entity.HasKey(e => e.IdFabricante)
                    .HasName("PK__fabrican__1F4C254A39C8F9D3");

                entity.ToTable("fabricante");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__producto__098892107E8D5670");

                entity.ToTable("producto");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("precio");

                entity.HasOne(d => d.IdFabricanteNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdFabricante)
                    .HasConstraintName("fk_IdFabricante");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
