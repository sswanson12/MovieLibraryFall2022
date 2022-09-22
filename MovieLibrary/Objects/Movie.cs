namespace MovieLibrary.Objects;

public class Movie
{
    private string? _title;
    private List<string> _genres;

    public Movie(int movieId, string? title, List<string> genres)
    {
        Id = movieId;
        _title = title;
        _genres = genres;
    }

    public int Id { get; set; }

    public string? Title
    {
        get => _title;
        set => _title = value ?? throw new ArgumentNullException(nameof(value));
    }

    public List<string> Genres
    {
        get => _genres;
        set => _genres = value ?? throw new ArgumentNullException(nameof(value));
    }

    public override string ToString()
    {
        var returnString = $"Id: {Id} - Title: {_title} - Genre(s): ";

        returnString = _genres.Aggregate(returnString, (current, genre) => current + $"{genre}, ");

        return returnString[..^2];
    }
}