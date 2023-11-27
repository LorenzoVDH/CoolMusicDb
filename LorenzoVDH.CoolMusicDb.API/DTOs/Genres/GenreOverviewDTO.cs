using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;

namespace LorenzoVDH.CoolMusicDb.API.DTOs.Genres;

public class GenreOverviewDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateOnly DateOfOrigin { get; set; }
    public string? Description { get; set; }
}
