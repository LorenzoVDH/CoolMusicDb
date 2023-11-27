using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace LorenzoVDH.CoolMusicDb.Infrastructure.Repositories.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        protected readonly CoolMusicDbContext _context;

        public ArtistRepository(CoolMusicDbContext context)
        {
            _context = context;
        }

        public async Task<List<Artist>> GetAllArtistsAsync()
        {
            return await _context.Artists.ToListAsync();
        }

        public async Task<Artist> CreateArtistAsync(Artist artist)
        {
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();
            return artist;
        }
    }
}
