using Microsoft.EntityFrameworkCore;
using projetBackAlbum.Models;

namespace projetBackAlbum.Context;

public class AlbumContext : DbContext
{
    public AlbumContext(DbContextOptions<AlbumContext> options)
        : base(options) { }

    public DbSet<Photo> photos { get; set; }
    public DbSet<Tag> tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=tcp:bddserveralbum.database.windows.net,1433;Initial Catalog=BDDalbum;Persist Security Info=False;User ID=adminira;Password=blondira100!!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}

//////


///////

/*   public class UserContext : DbContext
{

   public UserContext(DbContextOptions<UserContext> options) : base(options)
   {
   }
   public DbSet<User> tags { get; set; }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      if (!optionsBuilder.IsConfigured)
      {
         optionsBuilder.UseSqlServer("");
      }
   }
}*/
