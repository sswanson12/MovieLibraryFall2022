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
        
    }

    public void Empty()
    {
        _movieLibrary.Clear();
    }
}