using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using projetBackAlbum.Models;

namespace projetBackAlbum.DTO;

public class PostDTO
{
    public int PostId { get; set; }

    public string Name { get; set; } = string.Empty;

    //public string Comment { get; set; } = null!;

    //public DateTime CreatedAt { get; set; }
    //oneToMany
    public virtual ICollection<PhotoDTO> Photos { get; set; } = null!;

    //ManyTo One
    //public int? PostId { get; set; }     //????

    public virtual Post? Post { get; set; } = null!; //????

    public PostDTO()
    {
        //Photos = new HashSet<Photo>();
    }

    public Post ToPost()
    {
        return new Post
        {
            PostId = PostId,
            Name = Name,
            Photos = Photos.Select(PhotoDto => PhotoDto.ToPhoto()).ToList()
        };
    }
}
