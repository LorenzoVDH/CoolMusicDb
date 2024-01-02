using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;

namespace LorenzoVDH.CoolMusicDb.API.DTOs;

public class AlbumOverviewDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateOnly? ReleaseDate { get; set; }
    public List<ArtistSimpleDTO>? Artists { get; set; }
    public string? URL { get; set; }
}
