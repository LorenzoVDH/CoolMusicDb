namespace LorenzoVDH.CoolMusicDb.API.DTOs.Albums;

public class AlbumDetailDTO
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public DateOnly? ReleaseDate { get; set; }
    public string? URL { get; set; }
    public List<ArtistSimpleDTO>? Artists { get; set; }
}
