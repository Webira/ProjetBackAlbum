using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetBackAlbum.Context;
using projetBackAlbum.Models;

namespace projetBackAlbum.Controllers;

[Route("api/photo")]
[ApiController]
public class PhotoController : ControllerBase
{
    private readonly AlbumContext _context;

    public PhotoController(AlbumContext context)
    {
        _context = context;
    }

    // GET: api/Photo
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Photo>>> GetPhotos()
    {
        return await _context.photos.ToListAsync();
    }

    // GET: api/Photo/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Photo>> GetPhoto(int id)
    {
        var photo = await _context.photos.FindAsync(id);
        if (photo == null)
        {
            return NotFound();
        }
        return photo;
    }

    // PUT: api/Photo/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPhoto(int id, Photo photo)
    {
        if (id != photo.Id)
        {
            return BadRequest();
        }

        _context.Entry(photo).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PhotoExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Photo
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Photo>> PostPhoto(Photo photo)
    {
        _context.photos.Add(photo);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPhoto", new { id = photo.Id }, photo);
    }

    // DELETE: api/Photo/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePhoto(int id)
    {
        var photo = await _context.photos.FindAsync(id);
        if (photo == null)
        {
            return NotFound();
        }

        _context.photos.Remove(photo);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PhotoExists(int id)
    {
        return _context.photos.Any(e => e.Id == id);
    }
}
