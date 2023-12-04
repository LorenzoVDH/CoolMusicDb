using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;

namespace LorenzoVDH.CoolMusicDb.API.DTOs.Genres;

public class GenreDetailDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly? DateOfOrigin { get; set; }
    public string? Description { get; set; }
    public List<string>? CountryCodes { get; set; }
    public List<Genre>? SubGenres { get; set; }
}
