namespace MovieLibrary.Objects.Media;

public class Show : Media
{
    
    public int Id { get; set; }

    public string Title { get; set; }

    public int Season { get; set; }

    public int Episode { get; set; }

    public string?[] Writers { get; set; }
    
    public Show(int id, string title, int season, int episode, string?[] writers)
    {
        Id = id;
        Title = title;
        Season = season;
        Episode = episode;
        Writers = writers;
    }

    public override string Display()
    {
        var returnString = $"Id: {Id} - Title: {Title} - Season: {Season} - Episode {Episode} - Writers: ";

        returnString = Writers.Aggregate(returnString, (current, writer) => current + $"{writer}, ");

        return returnString[..^2];
    }
}