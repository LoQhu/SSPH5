using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SSPH5.Models;

public partial class H5sspToDoContext : DbContext
{
    public H5sspToDoContext()
    {
    }

    public H5sspToDoContext(DbContextOptions<H5sspToDoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cpr> Cprs { get; set; }

    public virtual DbSet<ToDoList> ToDoLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=H5SSP-ToDo;Trusted_Connection=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cpr>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Cpr");

            entity.Property(e => e.Cpr1)
                .HasMaxLength(500)
                .HasColumnName("Cpr");
            entity.Property(e => e.Hash).HasMaxLength(50);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Salt).HasMaxLength(500);
            entity.Property(e => e.User).HasMaxLength(500);
        });

        modelBuilder.Entity<ToDoList>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ToDoList");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ToDoItem).HasMaxLength(500);
            entity.Property(e => e.User).HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
