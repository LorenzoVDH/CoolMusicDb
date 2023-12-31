using System.ComponentModel.DataAnnotations;

namespace LorenzoVDH.CoolMusicDb.API.DTOs
{
    public class ArtistCreateDTO
    {
        public string? ArtistName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Description { get; set; }
        public DateOnly? DateOfBirth { get; set; }

        [Length(2, 2, ErrorMessage = "A CountryCode must be two characters long")]
        public string? CountryCode { get; set; }
    }
}