namespace LorenzoVDH.CoolMusicDb.ApplicationCore.Entities
{
    public class Artist : Entity 
    {
        private string? _pseudonym;
        public string? Pseudonym
        {
            get { 
                return _pseudonym; 
            }
            set
            {
                _pseudonym = value;
            }
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

        public List<Album> Albums
        {
            get; set; 
        }

        public Artist(string pseudonym) {
            Pseudonym = pseudonym;  
        }
        public Artist(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName; 
        }
    }
}
