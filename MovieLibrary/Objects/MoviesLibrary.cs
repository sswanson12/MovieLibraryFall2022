namespace MovieLibrary.Objects;

public class MoviesLibrary : Library<Movie>
{
    private readonly ILibrarian _librarian;
    
    private readonly List<Movie> _library;
    
    public MoviesLibrary(ILibrarian librarian)
    {
        _librarian = librarian;
        _library = new List<Movie>();
    }

    public override List<Movie> GetLibrary()
    {
        return _library;
    }

    public override bool AddMedia(Movie media)
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