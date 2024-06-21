using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetBackAlbum.Context;
using projetBackAlbum.DAO;
using projetBackAlbum.DTO;
using projetBackAlbum.Models;

//namespace projetBackAlbum.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : Controller
{
    //private readonly AlbumContext _context;
    private readonly UserDAO _userDao;

    public UserController(UserDAO userDao)
    {
        _userDao = userDao;
    }

    // GET: api/User
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var users = await _userDao.GetUsers();
        // return await _context.Users.Include(u => u.Tags).ToListAsync();
        return Ok(users);
        //.ToList();
    }

    // GET: api/User/5
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        //var User = await _context.Users.FindAsync(id);
        var user = await _userDao.GetUser(id);
        /*.Users.Include(user => user.Tags)
        .FirstOrDefaultAsync(u => u.Id == id);*/

        if (User == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    // PUT: api/User/5
    // To protect from overUsering attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(int id, User user)
    {
        //if (id != User.Id)
        if (id != user.UserId)
        {
            return BadRequest();
        }

        await _userDao.UpdateUser(user);
        /* var bdduser = await _userDao.Users.FindAsync(id);
         if (bdduser == null)
         {
             return NotFound();
         }*/

        /*bdduser.Tags = user.Tags;

        _userDao.Entry(bdduser).State = EntityState.Modified;

        try
        {
            await _userDao.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }*/

        return NoContent();
    }

    // User: api/User
    // To protect from overUsering attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<User>> PostUser(UserDTO userDTO)
    {
        /* var user = new User { Name = userDTO.Name };
        _context.Users.Add(userDTO);
        await _context.SaveChangesAsync();*/

        var user = userDTO.ToUser();
        await _userDao.AddUser(user);

        return CreatedAtAction("GetUser", new { id = user.UserId }, user);
    }

    // DELETE: api/User/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletedUser(int id)
    {
        var success = await _userDao.DeleteUser(id);
        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpPost("/add")]
    public async Task<ActionResult<User>> AddTag(AddDTO obj)
    {
        var reponse = _userDao.AddTag(obj.userId, obj.tagId);
        return CreatedAtAction("GetUser", reponse);
    }

    /*var user = await _userDao.Users.FindAsync(id);
    if (user == null)
    {
        return NotFound();
    }

    _userDao.Users.Remove(user);
    await _userDao.SaveChangesAsync();

    return NoContent();
}

private bool UserExists(int id)
{
    return _context.Users.Any(e => e.Id == id);
}*/
}
