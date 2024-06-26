using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using projetBackAlbum.DTO;

namespace projetBackAlbum.Models;

public class Photo
{
    [Key]
    public int PhotoId { get; set; }

    public string Name { get; set; } = null!;

    [Required]
    public string ImagePath { get; set; }

    public int? PostId { get; set; }

    [ForeignKey("PostId")]
    [JsonIgnore]
    public virtual Post? Post { get; set; } = null!;

    public PhotoDTO ToPhotoDTO()
    {
        return new PhotoDTO
        {
            PhotoId = PhotoId,
            Name = Name,
            ImagePath = ImagePath
        };
    }
}
