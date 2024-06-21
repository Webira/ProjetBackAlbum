using System.ComponentModel.DataAnnotations;
using projetBackAlbum.DTO;

namespace projetBackAlbum.Models;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    //manyToMany
    public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();

    // public virtual Tag Tag { get; set; } = null!;

    public User()
    {
        Tags = new HashSet<Tag>();
    }

    // ToDTO
    public UserDTO ToUserDTO()
    {
        return new UserDTO
        {
            UserId = UserId,
            Name = Name,
            Tags = Tags.Select(tag => tag.ToTagDTO()).ToList()
            //Tags = Tags.Select(tag => new TagDTO { TagId = tag.TagId, Title = tag.Title }).ToList()  //post???+
        };
    }



}
