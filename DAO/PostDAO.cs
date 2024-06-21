using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetBackAlbum.Context;
using projetBackAlbum.DTO;
using projetBackAlbum.Models;

namespace projetBackAlbum.DAO;

public class PostDAO
{
    private readonly AlbumContext _context;

    public PostDAO(AlbumContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Post>> GetPosts()
    {
        var reponse = await _context.Posts.Include(p => p.Photos).ToListAsync();
        return reponse;
    }

    public async Task<Post> GetPost(int id)
    {
        var reponse = await _context
            .Posts.Include(p => p.Photos)
            .FirstOrDefaultAsync(u => u.PostId == id);
        return reponse;
    }

    public async Task<Post> AddPost(Post post)
    {
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();

        if (post.TagId != 0)
        {
            var tag = await _context
                .Tags.Include(p => p.Posts)
                .FirstOrDefaultAsync(t => t.TagId == post.TagId.Value);

            tag.Posts.Add(post);
        }
        await _context.SaveChangesAsync();
        return post;
    }

    public async Task<Post> UpdatePost(Post Post)
    {
        _context.Entry(Post).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Post;
    }

    public async Task<bool> DeletePost(int id)
    {
        var Post = await _context.Posts.FindAsync(id);
        if (Post == null)
            return false;

        _context.Posts.Remove(Post);
        await _context.SaveChangesAsync();
        return true;
    }
}
