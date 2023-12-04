using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;

namespace LorenzoVDH.CoolMusicDb.API.DTOs.Genres;

public class GenreOverviewDTO
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Decade { get; set; }
    public DateOnly? DateOfOrigin { get; set; }
    public string? Description { get; set; }
    //public List<string>? Popular { get; set; }
    public string? SpotifyTrackPreviewId { get; set; }
    public List<string>? CountryCodes { get; set; }
    public List<GenreOverviewDTO> Children { get; set; } = new();
}
