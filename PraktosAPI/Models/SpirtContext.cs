using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PraktosAPI.Models;

public partial class SpirtContext : DbContext
{
    public SpirtContext()
    {
    }

    public SpirtContext(DbContextOptions<SpirtContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Athlete> Athletes { get; set; }

    public virtual DbSet<AthletesInMultipleSport> AthletesInMultipleSports { get; set; }

    public virtual DbSet<Competition> Competitions { get; set; }

    public virtual DbSet<CompetitionPlace> CompetitionPlaces { get; set; }

    public virtual DbSet<Participation> Participations { get; set; }

    public virtual DbSet<RecordBreakingAthlete> RecordBreakingAthletes { get; set; }

    public virtual DbSet<Sport> Sports { get; set; }

    public virtual DbSet<Top3ResultsOfKaravaevInRunning> Top3ResultsOfKaravaevInRunnings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost; Database=Spirt; User=sa; Password=sa; Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Athlete>(entity =>
        {
            entity.HasKey(e => e.AthleteId).HasName("PK__Athletes__56D7B318FEBAA7C5");

            entity.Property(e => e.AthleteId).HasColumnName("AthleteID");
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.MiddleName).HasMaxLength(100);
            entity.Property(e => e.Team).HasMaxLength(100);
        });

        modelBuilder.Entity<AthletesInMultipleSport>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("AthletesInMultipleSports");

            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.MiddleName).HasMaxLength(100);
        });

        modelBuilder.Entity<Competition>(entity =>
        {
            entity.HasKey(e => e.CompetitionId).HasName("PK__Competit__8F32F4F3A9027239");

            entity.Property(e => e.CompetitionId).HasColumnName("CompetitionID");
            entity.Property(e => e.CompetitionName).HasMaxLength(100);
            entity.Property(e => e.SportId).HasColumnName("SportID");
            entity.Property(e => e.SportLocation).HasMaxLength(100);

            entity.HasOne(d => d.Sport).WithMany(p => p.Competitions)
                .HasForeignKey(d => d.SportId)
                .HasConstraintName("FK__Competiti__Sport__3B75D760");
        });

        modelBuilder.Entity<CompetitionPlace>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CompetitionPlaces");

            entity.Property(e => e.CompetitionName).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.SportLocation).HasMaxLength(100);
            entity.Property(e => e.SportName).HasMaxLength(100);
        });

        modelBuilder.Entity<Participation>(entity =>
        {
            entity.HasKey(e => e.ParticipationsId).HasName("PK__Particip__4FEE4F34726E02FF");

            entity.Property(e => e.ParticipationsId).HasColumnName("ParticipationsID");
            entity.Property(e => e.AthleteId).HasColumnName("AthleteID");
            entity.Property(e => e.CompetitionId).HasColumnName("CompetitionID");
            entity.Property(e => e.Result).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SportId).HasColumnName("SportID");

            entity.HasOne(d => d.Athlete).WithMany(p => p.Participations)
                .HasForeignKey(d => d.AthleteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Participa__Athle__3E52440B");

            entity.HasOne(d => d.Competition).WithMany(p => p.Participations)
                .HasForeignKey(d => d.CompetitionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Participa__Compe__3F466844");

            entity.HasOne(d => d.Sport).WithMany(p => p.Participations)
                .HasForeignKey(d => d.SportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Participa__Sport__403A8C7D");
        });

        modelBuilder.Entity<RecordBreakingAthlete>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("RecordBreakingAthletes");

            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.MiddleName).HasMaxLength(100);
            entity.Property(e => e.Result).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SportName).HasMaxLength(100);
            entity.Property(e => e.WorldRecord).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Sport>(entity =>
        {
            entity.HasKey(e => e.SportId).HasName("PK__Sports__7A41AF1C0EDE9D61");

            entity.Property(e => e.SportId).HasColumnName("SportID");
            entity.Property(e => e.SportName).HasMaxLength(100);
            entity.Property(e => e.UnitOfMeasurement).HasMaxLength(50);
            entity.Property(e => e.WorldRecord).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Top3ResultsOfKaravaevInRunning>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Top3ResultsOfKaravaevInRunning");

            entity.Property(e => e.BestResult).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.SportName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
