using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using projetBackAlbum.Models;
namespace projetBackAlbum.DTO;

public class PhotoDTO
{
    public int PhotoId { get; set; }

    public string Name { get; set; } = null!;

    public string ImagePath { get; set; }

    public int? PostId { get; set; }

   // [ForeignKey("PostId")]
    //[JsonIgnore]
    public virtual Post? Post { get; set; } = null!;

    public PhotoDTO()
    {
        //Photos = new HashSet<Photo>();
    }

    public Photo ToPhoto()
    {
        return new Photo
        {
            PhotoId = PhotoId,
            Name = Name,
            ImagePath = ImagePath

        };
    }

}
