namespace MovieLibrary.Objects.Media;

public class Movie : Media
{
    private List<string> _genres;

    public Movie(int movieId, string? title, List<string> genres)
    {
        Id = movieId;
        Title = title;
        _genres = genres;
    }



    public List<string> Genres
    {
        get => _genres;
        set => _genres = value ?? throw new ArgumentNullException(nameof(value));
    }

    public override string Display()
    {
        var returnString = $"Type: Movie - Id: {Id} - Title: {Title} - Genre(s): ";

        returnString = _genres.Aggregate(returnString, (current, genre) => current + $"{genre}, ");

        return returnString[..^2];
    }
}