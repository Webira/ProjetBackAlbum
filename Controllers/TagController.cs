using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetBackAlbum.Context;
using projetBackAlbum.DAO;
using projetBackAlbum.Models;

namespace projetBackAlbum.Controllers;

[Route("api/tag")]
[ApiController]
public class TagController : Controller
{
    private readonly TagDAO _DAO;

    public TagController(TagDAO Dao)
    {
        _DAO = Dao;
    }

    // GET: api/Tag
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tag>>> GetTags()
    {
        var response = await _DAO.GetTags();
        return Ok(response);
    }

    // GET: api/Tag/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Tag>> GetTag(int id)
    {
        var response = await _DAO.GetTag(id);
        if (response == null)
        {
            return NotFound();
        }
        return response;
    }

    // PUT: api/Tag/5
    // To protect from overTaging attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTag(int id, Tag tag)
    {
        if (id != tag.TagId)
        {
            return BadRequest();
        }

        var reponse = await _DAO.UpdateTag(tag);

        return Ok(reponse);
    }

    // Tag: api/Tag
    // To protect from overTaging attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Tag>> Tag(Tag tag)
    {
        var response = await _DAO.AddTag(tag);

        return CreatedAtAction("GetTag", response);
    }

    // DELETE: api/Tag/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTag(int id)
    {
        var Tag = await _DAO.DeleteTag(id);
        if (!Tag)
        {
            return NotFound();
        }
        return NoContent();
    }
}
