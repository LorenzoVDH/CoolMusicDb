namespace LorenzoVDH.CoolMusicDb.API.DTOs.Artists;

public class ArtistUpdateDTO
{
    public int Id { get; set; }
    public string? ArtistName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Description { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public string? CountryCode { get; set; }
}
