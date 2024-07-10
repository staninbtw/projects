using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Bank.Models;

public partial class BankContext : DbContext
{
    public BankContext()
    {
    }

    public BankContext(DbContextOptions<BankContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<Check> Checks { get; set; }

    public virtual DbSet<Creditoff> Creditoffs { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server = localhost; initial catalog = Bank; trusted_connection = true; TrustServerCertificate = true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Card_1");

            entity.ToTable("Card");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cvc).HasColumnName("CVC");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Number)
                .HasMaxLength(19)
                .IsUnicode(false);
            entity.Property(e => e.Picture).HasColumnName("picture");
            entity.Property(e => e.Term).HasColumnType("date");
            entity.Property(e => e.Validity).HasMaxLength(10);

            entity.HasOne(d => d.CardownerNavigation).WithMany(p => p.Cards)
                .HasForeignKey(d => d.Cardowner)
                .HasConstraintName("FK_Card_User");
        });

        modelBuilder.Entity<Check>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Check");

            entity.HasOne(d => d.User).WithMany(p => p.Checks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Checks_User");
        });

        modelBuilder.Entity<Creditoff>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Creditoff");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Off).HasColumnName("off");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Role_1");

            entity.ToTable("Role");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Role1)
                .HasMaxLength(50)
                .HasColumnName("Role");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_User_1");

            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Mail).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Role)
                .HasConstraintName("FK_User_Role1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
