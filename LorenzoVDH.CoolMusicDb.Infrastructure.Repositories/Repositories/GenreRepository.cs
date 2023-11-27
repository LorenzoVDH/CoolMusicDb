using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace LorenzoVDH.CoolMusicDb.Infrastructure.Repositories.Repositories;

public class GenreRepository : IGenreRepository
{
    protected readonly CoolMusicDbContext _context;

    public GenreRepository(CoolMusicDbContext context)
    {
        _context = context;
    }

    public async Task<List<Genre>> GetMainGenresAsync()
    {
        return await _context.Genres.Where(g => g.ParentGenres.Count == 0).Include(gg => gg.SubGenres).ToListAsync();
    }

    public async Task<List<Genre>> GetSubGenresByParentId(int genreId)
    {
        var parentGenre = await _context.Genres.Where(g => g.Id == genreId).FirstAsync();
        var subGenres = await _context.Genres.Where(g => g.ParentGenres.Contains(parentGenre)).ToListAsync();

        return subGenres;
    }

    public async Task CreateGenreAsync(Genre genre)
    {
        _context.Genres.Add(genre);
        await _context.SaveChangesAsync();
    }
}
