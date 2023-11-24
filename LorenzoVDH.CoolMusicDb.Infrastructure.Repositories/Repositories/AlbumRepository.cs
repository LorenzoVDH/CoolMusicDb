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
            var albums = await _context.Albums.Include(a => a.Artists)
                                              .ToListAsync();

            return albums;
        }
    }
}