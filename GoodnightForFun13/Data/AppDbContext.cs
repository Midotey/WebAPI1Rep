using System;
using System.Collections.Generic;
using GoodnightForFun13.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodnightForFun13.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Folder> Folders { get; set; }
    public virtual DbSet<Note> Notes { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MyWebAPI1;Username=postgres;Password=1122331");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasIndex(e => e.FolderId, "IX_Notes_FolderId");

            entity.HasOne(d => d.Folder).WithMany(p => p.Notes).HasForeignKey(d => d.FolderId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
