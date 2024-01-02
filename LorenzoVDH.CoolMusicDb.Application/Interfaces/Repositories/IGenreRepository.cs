using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;

namespace LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;

public interface IGenreRepository
{
    Task<List<Genre>> GetGenresAsync();
    Task<List<Genre>> GetMainGenresAsync();
    Task<List<Genre>> GetSubGenresByParentIdAsync(int genreId);
    Task<Genre> CreateGenreAsync(Genre genre);
    Task CreateGenreParentChildRelationshipAsync(int parentGenreId, int childGenreId);
    Task DeleteGenreAsync(int genreId);
    Task DeleteGenreParentChildRelationshipAsync(int parentId, int childId);
    Task UpdateGenreAsync(Genre genre);
    Task AddPopularArtistToGenre(int popularArtistId, int genreId);
    Task RemovePopularArtistFromGenre(int popularArtistId, int genreId);
    Task<Genre?> GetGenreByIdAsync(int genreId);
    Task<List<Genre>> GetAllGenresWithoutHierarchyAsync();
    Task SetParentChildRelationshipsForGenre(int genreId, List<int> childGenreIds);
}
