using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetBackAlbum.Context;
using projetBackAlbum.DAO;
using projetBackAlbum.Models;

namespace projetBackAlbum.Controllers;

[Route("api/post")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly PostDAO _DAO;

    public PostController(PostDAO dao)
    {
        _DAO = dao;
    }

    // GET: api/Post
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
    {
        return Ok(await _DAO.GetPosts());
    }

    // GET: api/Post/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Post>> GetPost(int id)
    {
        return Ok(await _DAO.GetPost(id));
    }

    // PUT: api/Post/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPost(int id, Post post)
    {
        if (id != post.PostId)
        {
            return BadRequest();
        }
        await _DAO.UpdatePost(post);

        return NoContent();
    }

    // POST: api/Post
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Post>> PostPost(Post post)
    {
        return CreatedAtAction("GetPost", await _DAO.AddPost(post));
    }

    // DELETE: api/Post/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        await _DAO.DeletePost(id);
        return NoContent();
    }
}
