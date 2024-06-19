namespace projetBackAlbum.Models;

public class Post
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Comment { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();
    public int IdTag { get; set; }

    public virtual Tag IdTagNavigation { get; set; } = null!;
}
