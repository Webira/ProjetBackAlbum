using Microsoft.EntityFrameworkCore;
using projetBackAlbum.Models;

namespace projetBackAlbum.Context;

public class AlbumContext : DbContext
{
    public AlbumContext(DbContextOptions<AlbumContext> options)
        : base(options) { }

    public DbSet<Photo> Photos { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<User> Users { get; set; }
    //public DbSet<UserTags> UsersTags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=tcp:bddserveralbum.database.windows.net,1433;Initial Catalog=BDDalbum;Persist Security Info=False;User ID=adminira;Password=blondira100!!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            );
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder
            .Entity<User>()
            .HasMany(ph => ph.Tags)
            .WithMany(t => t.Users)
            .UsingEntity(j => j.ToTable("UserTags"));

            //------------------------------

        /*modelBuilder.Entity<UserTags>()
            .HasKey(sc => new { sc.UserId, sc.TagId });

        modelBuilder.Entity<UserTags>()
            .HasOne(sc => sc.User)
            .WithMany(s => s.UserTags)
            .HasForeignKey(sc => sc.UserId);

        modelBuilder.Entity<UserTags>()
            .HasOne(sc => sc.Tag)
            .WithMany(c => c.UserTags)
            .HasForeignKey(sc => sc.TagId);*/




        /* modelBuilder
            .Entity<Tag>()
            .HasMany(t => t.Posts)
            .WithOne(pt => pt.Tags)
            .HasForeingKey(pt => pt.PostId);*/
    }
}
