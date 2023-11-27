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

    public async Task<Genre> CreateGenreAsync(Genre genre)
    {
        _context.Genres.Add(genre);
        await _context.SaveChangesAsync();
        return genre;
    }

    public async Task CreateGenreParentChildRelationship(int parentId, int childId)
    {
        Genre parentGenre = await _context.Genres.Where(g => g.Id == parentId).FirstAsync();

        if (parentGenre == null)
            throw new InvalidOperationException("Parent genre not found!");

        Genre childGenre = await _context.Genres.Where(g => g.Id == childId).FirstAsync();

        if (childGenre == null)
            throw new InvalidOperationException("Child genre not found!");

        parentGenre.SubGenres.Add(childGenre);

        await _context.SaveChangesAsync();
    }
}
