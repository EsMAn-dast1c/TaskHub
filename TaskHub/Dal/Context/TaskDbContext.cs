using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dal.Context;

public class TaskDbContext : DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options)
        : base(options)
    {
    }

    public DbSet<TaskEntity> Tasks => Set<TaskEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id)
                .HasColumnName("id");

            entity.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(200);

            entity.Property(x => x.LastActivityUtc)
                .HasColumnName("last_activity_utc")
                .IsRequired();
        });

        modelBuilder.Entity<TaskEntity>(entity =>
        {
            entity.ToTable("tasks");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id)
                .HasColumnName("id");

            entity.Property(x => x.Title)
                .HasColumnName("title")
                .HasMaxLength(200)
                .IsRequired(false);

            entity.Property(x => x.CreatedByUserId)
                .HasColumnName("created_by_user_id")
                .IsRequired();

            entity.Property(x => x.CreatedUtc)
                .HasColumnName("created_utc")
                .IsRequired();

            entity.HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.CreatedByUserId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}