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

    public async Task<List<Genre>> GetGenresAsync()
    {
        //Get all the genres 
        var genres = await _context.Genres
                                   .OrderBy(g => g.Id)
                                   .Include(g => g.SubGenres)
                                   .Include(g => g.PopularArtists)
                                   .ToListAsync();

        //Filter out the SubGenres/ChildGenres that are not properly nested 
        genres.RemoveAll(g => g.ParentGenres.Count != 0);

        return genres;
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
        Genre parentGenre = await _context.Genres.Where(pg => pg.Id == parentId).Include(pg => pg.SubGenres).FirstAsync();

        if (parentGenre == null)
            throw new InvalidOperationException("Parent genre not found!");

        Genre childGenre = await _context.Genres.Where(cg => cg.Id == childId).FirstAsync();

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

    public async Task UpdateGenreAsync(Genre genre)
    {
        _context.Genres.Update(genre);
        await _context.SaveChangesAsync();
    }

    public async Task AddPopularArtistToGenre(int popularArtistId, int genreId)
    {
        Artist popularArtist = await _context.Artists.Where(a => a.Id == popularArtistId).FirstAsync();

        if (popularArtist == null)
            throw new InvalidOperationException("Artist not found!");

        Genre genre = await _context.Genres.Where(g => g.Id == genreId).Include(g => g.PopularArtists).FirstAsync();

        if (genre == null)
            throw new InvalidOperationException("Genre not found!");

        if (genre.PopularArtists == null)
            genre.PopularArtists = new();

        genre.PopularArtists.Add(popularArtist);
        await _context.SaveChangesAsync();
    }
}
