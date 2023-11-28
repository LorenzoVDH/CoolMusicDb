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

        public async Task<int> GetTotalArtistCountAsync()
        {
            return await _context.Artists.CountAsync();
        }

        public async Task<List<Artist>> GetAllArtistsAsync(int pageIndex, int pageSize)
        {
            var startIndex = pageIndex * pageSize;

            var artists = await _context.Artists.OrderBy(alb => alb.Id)
                                                .Skip(startIndex)
                                                .Take(pageSize)
                                                .ToListAsync();

            return artists;
        }

        public async Task<Artist> CreateArtistAsync(Artist artist)
        {
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();
            return artist;
        }

        public async Task<Artist?> GetArtistByIdAsync(int artistId)
        {
            return await _context.Artists.Where(a => a.Id == artistId).Include(a => a.Albums).FirstOrDefaultAsync();
        }
    }
}
