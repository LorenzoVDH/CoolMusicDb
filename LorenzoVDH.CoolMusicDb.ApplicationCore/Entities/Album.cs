namespace LorenzoVDH.CoolMusicDb.ApplicationCore.Entities
{
    public class Album : Entity
    {
        private string? _name;
        public string? Name
        {
            get => _name; set => _name = value;
        }

        private DateOnly? _releaseDate;
        public DateOnly? ReleaseDate
        {
            get => _releaseDate; set => _releaseDate = value;
        }

        private string? _url;
        public string? URL
        {
            get => _url; set => _url = value;
        }

        private List<Artist> _artists = new();
        public List<Artist> Artists
        {
            get => _artists; set => _artists = value;
        }
    }
}
