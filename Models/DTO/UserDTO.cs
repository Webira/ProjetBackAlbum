using System.ComponentModel.DataAnnotations;
using projetBackAlbum.Models;

namespace projetBackAlbum.DTO;

public class UserDTO
{
    public int UserId { get; set; }

    public string Name { get; set; } = string.Empty;

    public List<TagDTO> Tags { get; set; } = new List<TagDTO>();

    public UserDTO()
    {
        //Tags = new HashSet<Tag>();
    }

    // From DTO ToUser 
    public User ToUser()
    {
        return new User
        {
            UserId = UserId,
            Name = Name,
            Tags = Tags.Select(tagDto => tagDto.ToTag()).ToList()
        };
    }
}
