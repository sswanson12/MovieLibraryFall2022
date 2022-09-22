namespace MovieLibrary.Objects;

public interface ILibrary
{
    public List<Movie> GetLibrary();

    public bool AddMedia(Movie movie);

    public void Empty();
}