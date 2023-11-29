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
        return await _context.Genres.Where(g => g.ParentGenres.Count == 0).OrderBy(alb => alb.Id).Include(gg => gg.SubGenres).ToListAsync();
    }

    public async Task<List<Genre>> GetSubGenresByParentIdAsync(int genreId)
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

    public async Task CreateGenreParentChildRelationshipAsync(int parentId, int childId)
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

    public async Task DeleteGenreAsync(int genreId)
    {
        var genreToDelete = await _context.Genres.Where(g => g.Id == genreId).FirstAsync();

        if (genreToDelete == null)
            throw new InvalidOperationException("Genre is not found!");

        _context.Genres.Remove(genreToDelete);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteGenreParentChildRelationshipAsync(int parentId, int childId)
    {
        Genre parentGenre = await _context.Genres.Where(g => g.Id == parentId).Include(pg => pg.SubGenres).FirstAsync();

        if (parentGenre == null)
            throw new InvalidOperationException("Parent genre not found!");

        Genre childGenre = await _context.Genres.Where(g => g.Id == childId).FirstAsync();

        if (childGenre == null)
            throw new InvalidOperationException("Child genre not found!");

        parentGenre.SubGenres.Remove(childGenre);
        await _context.SaveChangesAsync();
    }
}
