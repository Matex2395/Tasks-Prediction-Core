using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AdminMVC.Models;

public partial class AdminMvcContext : DbContext
{
    public AdminMvcContext()
    {
    }

    public AdminMvcContext(DbContextOptions<AdminMvcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Initial Catalog=AdminMVC;User ID=MateoSA;Password=empanada123;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__23CAF1D81A434EC4");

            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.CategoryDescription)
                .HasMaxLength(255)
                .HasColumnName("categoryDescription");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .HasColumnName("categoryName");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__Tasks__DD5D5A42286E7939");

            entity.Property(e => e.TaskId).HasColumnName("taskId");
            entity.Property(e => e.ActualTime).HasColumnName("actualTime");
            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("creationDate");
            entity.Property(e => e.EstimatedTime).HasColumnName("estimatedTime");
            entity.Property(e => e.TaskName)
                .HasMaxLength(100)
                .HasColumnName("taskName");
            entity.Property(e => e.TaskState)
                .HasMaxLength(50)
                .HasDefaultValue("In Progress")
                .HasColumnName("taskState");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Category).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Tasks__categoryI__534D60F1");

            entity.HasOne(d => d.User).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Tasks__userId__52593CB8");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__CB9A1CFF1714BBE7");

            entity.HasIndex(e => e.UserEmail, "UQ__Users__D54ADF555E66784B").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("createdAt");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(100)
                .HasColumnName("userEmail");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .HasColumnName("userName");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(100)
                .HasColumnName("userPassword");
            entity.Property(e => e.UserRole)
                .HasMaxLength(50)
                .HasDefaultValue("Developer")
                .HasColumnName("userRole");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
