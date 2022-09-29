namespace MovieLibrary.Objects;

public class Show
{
    
    public int Id { get; set; }

    private string Title { get; set; }

    private int Season { get; set; }

    private int Episode { get; set; }

    private string[] Writers { get; set; }
    
    public Show(int id, string title, int season, int episode, string[] writers)
    {
        Id = id;
        Title = title;
        Season = season;
        Episode = episode;
        Writers = writers;
    }
}