using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;

namespace LorenzoVDH.CoolMusicDb.API.DTOs;

public class AlbumOverviewDTO
{
    public string? Name { get; set; }
    public DateOnly? ReleaseDate { get; set; }
    public List<Artist>? Artists { get; set; }
    public string? URL { get; set; }
}
