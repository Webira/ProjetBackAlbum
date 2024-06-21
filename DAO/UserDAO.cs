using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetBackAlbum.Context;
using projetBackAlbum.DTO;
using projetBackAlbum.Models;

namespace projetBackAlbum.DAO;

public class UserDAO
{
    private readonly AlbumContext _context;

    public UserDAO(AlbumContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _context
            .Users. /*Include(u => u.Tags)*/
            Include(ut => ut.Tags)
            .ThenInclude(p => p.Posts)
            .ToListAsync();
    }

    //--------------------------------------------------------------

    public async Task<User> GetUser(int id)
    {
        return await _context
            .Users //Include(u => u.Tags)
            .Include(ut => ut.Tags)
            .ThenInclude(p => p.Posts)
            .FirstOrDefaultAsync(u => u.UserId == id);
    }

    //------------------------------------//

/*public async Task<User> AddTagUser(int userId, int tagId)
{
        var newUser = new User{};
        var newTag = new Tag{};


        newUser.UserTags.Add(new UserTags { Tag = newTag });

        await _context.SaveChangesAsync();

         return newUser;
}*/


//---------------------------------//


    public async Task<User> AddTag(int userid, int tagid)
    {
        var myuser = await _context
            .Users //Include(u => u.Tags)
            .Include(ut => ut.Tags)
            .FirstOrDefaultAsync(u => u.UserId == userid);

        var myTag = await _context
            .Tags.Include(ut => ut.Users)
            .FirstOrDefaultAsync(u => u.TagId == tagid);

        myTag.Users.Add(myuser);
        myuser.Tags.Add(myTag);

        await _context.SaveChangesAsync();

        return myuser;
    }

    public async Task<User> AddUser(User User)
    {
        _context.Users.Add(User);
        await _context.SaveChangesAsync();
        return User;
    }

    public async Task<User> UpdateUser(User User)
    {
        _context.Entry(User).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return User;
    }

    public async Task<bool> DeleteUser(int id)
    {
        var User = await _context.Users.FindAsync(id);
        if (User == null)
            return false;

        _context.Users.Remove(User);
        await _context.SaveChangesAsync();
        return true;
    }
}
