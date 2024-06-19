namespace projetBackAlbum.Models;

public class Photo
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    //public string Comment { get; set; }
    //public DateTime CreatedAt { get; set; }
    public int IdPost { get; set; }

    public virtual Post IdPostNavigation { get; set; } = null!;
}

