using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EstebanVasquez_Parcial2_API.Models
{
    public partial class EXAMEN_FINAL_PROGRA6Context : DbContext
    {
        public EXAMEN_FINAL_PROGRA6Context()
        {
        }

        public EXAMEN_FINAL_PROGRA6Context(DbContextOptions<EXAMEN_FINAL_PROGRA6Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Activo> Activos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("SERVER=.;DATABASE=EXAMEN_FINAL_PROGRA6; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activo>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__Activo__40F9A20781228200");

                entity.ToTable("Activo");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Area)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("area");

                entity.Property(e => e.Costo)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("costo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
