using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Glossary.Models.GlossaryLite;

public partial class GlossaryContext : DbContext
{
    public GlossaryContext()
    {
    }

    public GlossaryContext(DbContextOptions<GlossaryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Definition> Definitions { get; set; }

    public virtual DbSet<Term> Terms { get; set; }

    private readonly IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite(config.GetValue<string>("ConnectionStrings:GlossaryEntityLite"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Definition>(entity =>
        {
            entity.ToTable("Definition");

            entity.HasIndex(e => e.TermId, "Definition_UQ__Definiti__410A21A44F3DC1C9")
                .IsUnique()
                .IsDescending();

            entity.Property(e => e.Description)
                .UseCollation("NOCASE")
                .HasColumnType("varchar(1000)");

            entity.HasOne(d => d.Term).WithOne(p => p.Definition)
                .HasForeignKey<Definition>(d => d.TermId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Term>(entity =>
        {
            entity.ToTable("Term");

            entity.Property(e => e.Name)
                .UseCollation("NOCASE")
                .HasColumnType("varchar(50)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
