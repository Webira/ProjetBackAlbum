using System.ComponentModel.DataAnnotations;
using projetBackAlbum.Models;

namespace projetBackAlbum.DTO;

public class TagDTO
{
    public int TagId { get; set; }

    public string Title { get; set; } = string.Empty;

    public virtual ICollection<UserDTO> Users { get; set; }

    public virtual ICollection<PostDTO> Posts { get; set; }

    //public List<PostDto> Posts { get; set; }     //??????

    public Tag ToTag()
    {
        return new Tag
        {
            TagId = TagId,
            Title = Title,
            Posts = Posts.Select(posts => posts.ToPost()).ToList(),
            Users = Users.Select(users => users.ToUser()).ToList()
        };
    }
}
