using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;

namespace LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories
{
    public interface IArtistRepository
    {
        Task<List<Artist>> GetAllArtistsAsync(); 
        Task CreateArtistAsync(Artist artist);
    }
}
