using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using projetBackAlbum.Models;

namespace projetBackAlbum.DTO;

public class AddDTO
{
    public int userId;
    public int tagId;
}
