using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExceptionLog.Models;

public partial class ExceptionLogContext : DbContext
{
    public ExceptionLogContext()
    {
    }

    public ExceptionLogContext(DbContextOptions<ExceptionLogContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Log> Logs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SNNB-PC02;database=ExceptionLog;Persist Security Info=True;User ID=Collector;Password=btp1997; Trusted_Connection=true; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Log>(entity =>
        {
            entity.ToTable("Log");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Additional)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Application)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.MemberName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Message)
                .HasMaxLength(1024)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
