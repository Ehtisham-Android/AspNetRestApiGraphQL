using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RestApiGraphQL.Models.Emp;

public partial class RestApiGraphQldbContext : DbContext
{
    public RestApiGraphQldbContext()
    {
    }

    public RestApiGraphQldbContext(DbContextOptions<RestApiGraphQldbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmpTbl> EmpTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ehtisham\\sqlexpress;Database=RestApiGraphQLDB;Encrypt=false;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmpTbl>(entity =>
        {
            entity.ToTable("emp_tbl");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("city");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
