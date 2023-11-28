using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;

namespace LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;

public interface IGenreRepository
{
    Task<List<Genre>> GetMainGenresAsync();
    Task<List<Genre>> GetSubGenresByParentIdAsync(int genreId);
    Task<Genre> CreateGenreAsync(Genre genre);
    Task CreateGenreParentChildRelationshipAsync(int parentGenreId, int childGenreId);
}
