using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;

namespace LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories
{
    public interface IArtistRepository
    {
        Task<int> GetTotalArtistCountAsync();
        Task<List<Artist>> GetAllArtistsAsync(int pageIndex, int pageSize);
        Task<Artist> CreateArtistAsync(Artist artist);
        Task<Artist?> GetArtistByIdAsync(int artistId);
        Task DeleteArtistByIdAsync(int artistId);
        Task UpdateArtistAsync(Artist artist);
        Task<List<Artist>> GetArtistsByNameAsync(string query);
    }
}
