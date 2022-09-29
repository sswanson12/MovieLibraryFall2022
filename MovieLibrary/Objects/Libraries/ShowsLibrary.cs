using MovieLibrary.Objects.Media;

namespace MovieLibrary.Objects.Libraries;

public class ShowsLibrary : Library<Show>
{
    private readonly ILibrarian _librarian;
    
    private readonly List<Show> _library;
    
    public ShowsLibrary(ILibrarian librarian)
    {
        _librarian = librarian;
        _library = new List<Show>();
    }

    public override List<Show> GetLibrary()
    {
        return _library;
    }

    public override bool AddMedia(Show media)
    {
        if (_librarian.CheckId(media, _library))
        {
            return false;
        }

        media.Id = _librarian.IssueId(_library);

        _library.Add(media);

        return true;
    }

    public override void Empty()
    {
        _library.Clear();
    }
}