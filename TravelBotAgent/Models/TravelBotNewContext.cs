using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TravelBotAgent.Models;

public partial class TravelBotNewContext : DbContext
{
    public TravelBotNewContext()
    {
    }

    public TravelBotNewContext(DbContextOptions<TravelBotNewContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Interaction> Interactions { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=WJLP-3582\\SQLEXPRESS; database=TravelBotNew; trusted_connection=true; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Interaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Interact__3214EC07609E33C6");

            entity.ToTable("Interaction");

            entity.Property(e => e.IncomingMessage).HasColumnType("text");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.OutGoingMessage).HasColumnType("text");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3214EC07F9ED0265");

            entity.ToTable("Question");

            entity.Property(e => e.QuestionData)
                .HasColumnType("text")
                .HasColumnName("Question_Data");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Session__3214EC07E5657C5D");

            entity.ToTable("Session");

            entity.Property(e => e.MobileNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
