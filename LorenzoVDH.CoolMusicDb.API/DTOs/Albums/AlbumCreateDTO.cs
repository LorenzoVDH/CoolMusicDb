namespace LorenzoVDH.CoolMusicDb.API.DTOs.Albums;

public class AlbumCreateDTO
{
    public string? Name { get; set; }
    public DateOnly? ReleaseDate { get; set; }
    public string? URL { get; set; }
}
