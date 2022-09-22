namespace MovieLibrary.Objects;

public class Library : ILibrary
{
    private readonly List<Movie> _movieLibrary;

    public Library()
    {
        _movieLibrary = new List<Movie>();
    }

    public List<Movie> GetLibrary()
    {
        return _movieLibrary;
    }

    public void AddMedia(Movie movie)
    {
        _movieLibrary.Add(movie);
    }

    public void Empty()
    {
        _movieLibrary.Clear();
    }
}