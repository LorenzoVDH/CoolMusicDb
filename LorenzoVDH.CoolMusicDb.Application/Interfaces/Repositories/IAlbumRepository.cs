using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;

namespace LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories
{
    public interface IAlbumRepository
    {
        Task<List<Album>> GetAllAlbumsAsync();
        Task<List<Album>> GetAlbumsByArtistIdAsync(int artistId);
        Task CreateAlbumAsync(Album album);
    }
}