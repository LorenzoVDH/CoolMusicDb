using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;

namespace LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;

public interface IGenreRepository
{
    Task<List<Genre>> GetMainGenresAsync();
    Task<List<Genre>> GetSubGenresByParentId(int genreId);
    Task<Genre> CreateGenreAsync(Genre genre);
    Task CreateGenreParentChildRelationship(int parentGenreId, int childGenreId);
}
