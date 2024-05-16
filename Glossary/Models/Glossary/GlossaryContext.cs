using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Glossary.Models.Glossary
{
    public partial class GlossaryContext : DbContext
    {
        public GlossaryContext()
        {
        }

        public GlossaryContext(DbContextOptions<GlossaryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Definition> Definitions { get; set; } = null!;
        public virtual DbSet<Term> Terms { get; set; } = null!;

        private readonly IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(config.GetValue<string>("ConnectionStrings:GlossaryEntity"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Definition>(entity =>
            {
                entity.ToTable("Definition");

                entity.HasIndex(e => e.TermId, "UQ__Definiti__410A21A4E6531BCB")
                    .IsUnique();

                entity.Property(e => e.Description).IsUnicode(false);

                entity.HasOne(d => d.Term)
                    .WithOne(p => p.Definition)
                    .HasForeignKey<Definition>(d => d.TermId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_term");
            });

            modelBuilder.Entity<Term>(entity =>
            {
                entity.ToTable("Term");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
