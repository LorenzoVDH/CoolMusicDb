using System.ComponentModel.DataAnnotations;

namespace LorenzoVDH.CoolMusicDb.ApplicationCore.Entities
{
    public class Artist : Entity
    {
        //Name the musician is known as publically, can be the same as his or her first name
        private string? _artistName;
        public string? ArtistName
        {
            get
            {
                return _artistName;
            }
            set
            {
                _artistName = value;
            }
        }

        private string? _description;
        public string? Description
        {
            get => _description;
            set => _description = value;
        }

        private string? _firstName;
        public string? FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }

        private string? _lastName;

        public string? LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

        private DateOnly? _dateOfBirth;
        public DateOnly? DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                _dateOfBirth = value;
            }
        }

        private List<Album> albums = new();
        public List<Album> Albums
        {
            get
            {
                return albums;
            }
            set
            {
                albums = value;
            }
        }

        [Length(2, 2, ErrorMessage = "A CountryCode must be two characters long")]
        private string? _countryCode;
        public string? CountryCode
        {
            get
            {
                return _countryCode;
            }
            set
            {
                _countryCode = value?.ToUpper();
            }
        }

        public Artist(string artistName)
        {
            _artistName = artistName;
        }
    }
}
