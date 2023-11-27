namespace LorenzoVDH.CoolMusicDb.API.DTOs
{
    public class ArtistOverviewDTO
    {
        public int Id { get; set; }
        public string? ArtistName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? CountryCode { get; set; }
    }
}
