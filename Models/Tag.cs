using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projetBackAlbum.Models;

using projetBackAlbum.DTO;

public class Tag
{
    [Key]
    public int TagId { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    //ManyToMany
    public virtual ICollection<User> Users { get; set; } = new HashSet<User>();

    //OneToMany
    public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();

    //public Post Post { get; set; }

    public Tag()
    {
        Users = new HashSet<User>();
        Posts = new HashSet<Post>();
    }

    // ToDTO
    public TagDTO ToTagDTO()
    {
        return new TagDTO
        {
            TagId = TagId,
            Title = Title,
            Users = Users.Select(user => user.ToUserDTO()).ToList(),
            Posts = Posts.Select(post => post.ToPostDTO()).ToList()
        };
    }
}
