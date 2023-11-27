using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace LorenzoVDH.CoolMusicDb.Infrastructure.Repositories.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        protected readonly CoolMusicDbContext _context;

        public AlbumRepository(CoolMusicDbContext context)
        {
            _context = context;
        }

        public async Task<List<Album>> GetAllAlbumsAsync()
        {
            var albums =
                await _context.Albums
                    .Include(alb => alb.Artists)
                    .ToListAsync();

            return albums;
        }

        public async Task<List<Album>> GetAlbumsByArtistIdAsync(int artistId)
        {
            var albums =
                await _context.Albums.Where(alb => alb.Artists.Any(a => a.Id == artistId))
                                                              .Include(alb => alb.Artists)
                                                              .ToListAsync();

            return albums;
        }

        public async Task<Album> CreateAlbumAsync(Album album)
        {
            _context.Albums.Add(album);
            await _context.SaveChangesAsync();
            return album;
        }

        public async Task CreateAlbumArtistRelationshipAsync(int albumId, int artistId)
        {
            var album = await _context.Albums.Where(alb => alb.Id == albumId).FirstAsync();

            if (album == null)
                throw new InvalidOperationException("Album is not found!");

            var artist = await _context.Artists.Where(art => art.Id == artistId).FirstAsync();

            if (artist == null)
                throw new InvalidOperationException("Artist is not found!");

            album.Artists.Add(artist);
            await _context.SaveChangesAsync();
        }

        public async Task<Album> UpdateAlbumAsync(Album album)
        {
            _context.Albums.Update(album);
            await _context.SaveChangesAsync();

            return album;
        }

        public async Task DeleteAlbumAsync(int albumId)
        {
            var albumToDelete = await _context.Albums.Where(a => a.Id == albumId).FirstAsync();

            if (albumToDelete == null)
                throw new InvalidOperationException("Album is not found!");

            _context.Albums.Remove(albumToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
