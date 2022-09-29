namespace MovieLibrary.Objects;

public class Video
{
    public int Id { get; set; }

    private string Title { get; set; }

    private string Format { get; set; }

    private int Length { get; set; }

    private int[] Regions { get; set; }
    
    public Video(int id, string title, string format, int length, int[] regions)
    {
        Id = id;
        Title = title;
        Format = format;
        Length = length;
        Regions = regions;
    }
}