namespace LorenzoVDH.CoolMusicDb.API.DTOs.Genres;

public class GenreDetailDTO
{
    public string Name { get; set; }
    public DateOnly? DateOfOrigin { get; set; }
    public string? Description { get; set; }
}
