using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetBackAlbum.Context;
using projetBackAlbum.DTO;
using projetBackAlbum.Models;

namespace projetBackAlbum.DAO;

public class TagDAO
{
    private readonly AlbumContext _context;

    public TagDAO(AlbumContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tag>> GetTags()
    {
        return await _context.Tags.Include(ut => ut.Posts).ToListAsync();
    }

    public async Task<Tag> GetTag(int id)
    {
        return await _context.Tags.Include(ut => ut.Posts).FirstOrDefaultAsync(t => t.TagId == id);
        //.FindAsync(id);
    }

    public async Task<Tag> AddTag(Tag tag)
    {
        _context.Tags.Add(tag);
        await _context.SaveChangesAsync();
        return tag;
    }

    public async Task<Tag> UpdateTag(Tag Tag)
    {
        _context.Entry(Tag).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Tag;
    }

    public async Task<bool> DeleteTag(int id)
    {
        var Tag = await _context.Tags.FindAsync(id);
        if (Tag == null)
            return false;

        _context.Tags.Remove(Tag);
        await _context.SaveChangesAsync();
        return true;
    }
}
