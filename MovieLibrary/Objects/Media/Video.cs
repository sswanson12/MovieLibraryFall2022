namespace MovieLibrary.Objects.Media;

public class Video : Media
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Format { get; set; }

    public int Length { get; set; }

    public int[] Regions { get; set; }
    
    public Video(int id, string? title, string? format, int length, int[] regions)
    {
        Id = id;
        Title = title;
        Format = format;
        Length = length;
        Regions = regions;
    }

    public override string Display()
    {
        throw new NotImplementedException();
    }
}