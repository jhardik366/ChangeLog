using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IRepository.Models
{
    public partial class ChangeLogDbContext : DbContext
    {
        public ChangeLogDbContext()
        {
        }

        public ChangeLogDbContext(DbContextOptions<ChangeLogDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChangeArea> ChangeArea { get; set; }
        public virtual DbSet<ChangeInfo> ChangeInfo { get; set; }
        public virtual DbSet<ChangeType> ChangeType { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<ReleaseInfo> ReleaseInfo { get; set; }
        public virtual DbSet<RoleEnum> RoleEnum { get; set; }
        public virtual DbSet<RolePermissions> RolePermissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=AdminDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChangeArea>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<ChangeInfo>(entity =>
            {
                entity.HasOne(d => d.Area)
                    .WithMany(p => p.ChangeInfo)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_ChangeInfo_ChangeArea");

                entity.HasOne(d => d.Release)
                    .WithMany(p => p.ChangeInfo)
                    .HasForeignKey(d => d.ReleaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChangeInfo_ToReleaseInfo");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.ChangeInfo)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChangeInfo_ChangeType");
            });

            modelBuilder.Entity<ChangeType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<RoleEnum>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<RolePermissions>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.PermissionId })
                    .HasName("PK_RolePermission");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.RolePermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolePermission_Permission");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
