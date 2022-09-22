namespace MovieLibrary.Objects;

public interface ILibrary
{
    public List<Movie> GetLibrary();

    public void AddMedia(Movie movie);
}