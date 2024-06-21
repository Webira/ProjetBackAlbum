using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using projetBackAlbum.DTO;

namespace projetBackAlbum.Models;

public class Post
{
    [Key]
    public int PostId { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [StringLength(250)]
    public string Comment { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    //oneToMany
    public virtual ICollection<Photo> Photos { get; set; } = null!;

    //ManyTo One
    public int? TagId { get; set; }

    [ForeignKey("TagId")]
    public virtual Tag? Tag { get; set; } = null!;

    //public virtual Post IdPostNavigation { get; set; } = null!;

    public Post()
    {
        Photos = new HashSet<Photo>();
    }

    public PostDTO ToPostDTO()
    {
        return new PostDTO
        {
            PostId = PostId,
            Name = Name,
            Photos = Photos.Select(e => e.ToPhotoDTO()).ToList()
        };
    }
}
