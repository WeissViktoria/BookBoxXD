using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Model.Configurations;

public class BuchContext : DbContext
{
    public DbSet<Buch> Buecher { get; set; }
    public DbSet<Benutzer> Benutzer { get; set; }
    public DbSet<BuchBeziehung_JT> BuchBeziehung_JT { get; set; }
    
    public BuchContext(DbContextOptions<BuchContext> options): base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BuchBeziehung_JT>()
            .Property(b => b.Status)
            .HasConversion<string>();
        
        modelBuilder.Entity<BuchBeziehung_JT>()
            .HasOne(b => b.Buch)
            .WithMany()
            .HasForeignKey(b => b.BuchId);
        
        modelBuilder.Entity<BuchBeziehung_JT>()
            .HasOne(b => b.Benutzer)
            .WithMany()
            .HasForeignKey(b => b.BenutzerId);
        
        modelBuilder.Entity<BuchBeziehung_JT>()
            .HasKey(b => new { b.BuchId, b.BenutzerId, b.Status });

    }
}