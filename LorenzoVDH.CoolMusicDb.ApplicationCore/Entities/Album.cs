namespace LorenzoVDH.CoolMusicDb.ApplicationCore.Entities
{
    public class Album : Entity 
    {
        public string Name
        {
            get; set;
        }

        public DateTime ReleaseDate
        {
            get; set;
        }
        
        public string URL
        {
            get; set;
        }

        public List<Artist> Artists
        {
            get; set; 
        }
    }
}
