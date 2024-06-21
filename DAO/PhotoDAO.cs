using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetBackAlbum.Context;
using projetBackAlbum.DTO;
using projetBackAlbum.Models;

namespace projetBackAlbum.DAO;

public class PhotoDAO
{
    private readonly AlbumContext _context;

    public PhotoDAO(AlbumContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Photo>> GetPhotos()
    {
        return await _context.Photos.ToListAsync();
    }

    public async Task<Photo> GetPhoto(int id)
    {
        return await _context.Photos.FindAsync(id);
    }

    public async Task<Photo> AddPhoto(Photo photo)
    {
        _context.Photos.Add(photo);
        await _context.SaveChangesAsync();

        if (photo.PostId != 0)
        {
            var post = await _context
                .Posts.Include(p => p.Photos)
                .FirstOrDefaultAsync(p => p.PostId == photo.PostId.Value);

            post.Photos.Add(photo);
        }
        await _context.SaveChangesAsync();

        return photo;
    }

    public async Task<Photo> UpdatePhoto(Photo Photo)
    {
        _context.Entry(Photo).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Photo;
    }

    public async Task<bool> DeletePhoto(int id)
    {
        var Photo = await _context.Photos.FindAsync(id);
        if (Photo == null)
            return false;

        _context.Photos.Remove(Photo);
        await _context.SaveChangesAsync();
        return true;
    }
}
