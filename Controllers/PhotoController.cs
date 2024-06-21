using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetBackAlbum.Context;
using projetBackAlbum.DAO;
using projetBackAlbum.Models;

namespace projetBackAlbum.Controllers;

[Route("api/photo")]
[ApiController]
public class PhotoController : ControllerBase
{
    private readonly PhotoDAO _DAO;

    public PhotoController(PhotoDAO dao)
    {
        _DAO = dao;
    }

    // GET: api/Photo
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Photo>>> GetPhotos()
    {
        var response = await _DAO.GetPhotos();
        return Ok(response);
    }

    // GET: api/Photo/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Photo>> GetPhoto(int id)
    {
        var response = await _DAO.GetPhoto(id);
        return Ok(response);
    }

    // PUT: api/Photo/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPhoto(int id, Photo photo)
    {
        if (id != photo.PhotoId)
        {
            return BadRequest();
        }

        var result = await _DAO.UpdatePhoto(photo);
        return Ok(result);
    }

    // POST: api/Photo
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Photo>> PostPhoto(Photo photo)
    {
        var response = await _DAO.AddPhoto(photo);
        return Ok(response);
    }

    // DELETE: api/Photo/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePhoto(int id)
    {
        var response = await _DAO.DeletePhoto(id);
        return Ok(response);
    }
}
