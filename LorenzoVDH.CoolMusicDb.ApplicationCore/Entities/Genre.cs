namespace LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;

public class Genre : Entity
{

    private string? _name;
    public string? Name { get => _name; set => _name = value; }

    private DateOnly? _dateOfOrigin;
    public DateOnly? DateOfOrigin { get => _dateOfOrigin; set => _dateOfOrigin = value; }

    private string? _description;
    public string? Description { get => _description; set => _description = value; }

    private List<Genre> _parentGenres = new();
    public List<Genre> ParentGenres { get => _parentGenres; set => _parentGenres = value; }

    private List<Genre> _subGenres = new();
    public List<Genre> SubGenres { get => _subGenres; set => _subGenres = value; }
}
