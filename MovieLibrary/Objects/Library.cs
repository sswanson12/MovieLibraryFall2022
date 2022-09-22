namespace MovieLibrary.Objects;

public class Library : ILibrary
{
    private readonly ILibrarian _librarian;
    
    private readonly List<Movie> _movieLibrary;

    public Library(ILibrarian librarian)
    {
        _librarian = librarian;
        _movieLibrary = new List<Movie>();
    }

    public List<Movie> GetLibrary()
    {
        return _movieLibrary;
    }

    public bool AddMedia(Movie movie)
    {
        if (_librarian.CheckId(movie, _movieLibrary))
        {
            return false;
        }

        movie.Id = _librarian.IssueId(_movieLibrary);

        _movieLibrary.Add(movie);

        return true;
    }

    public void Empty()
    {
        _movieLibrary.Clear();
    }
}