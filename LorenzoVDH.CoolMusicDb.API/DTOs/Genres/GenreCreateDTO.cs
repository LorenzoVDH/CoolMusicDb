using System.ComponentModel.DataAnnotations;

namespace LorenzoVDH.CoolMusicDb.API.DTOs.Genres;

public class GenreCreateDTO
{
    [Required(ErrorMessage = "A genre needs a name")]
    public string Name { get; set; }
    public DateOnly? DateOfOrigin { get; set; }
    public string? Description { get; set; }
    public List<string>? CountryCodes { get; set; }
    public string? SpotifyTrackPreviewId { get; set; }
}
