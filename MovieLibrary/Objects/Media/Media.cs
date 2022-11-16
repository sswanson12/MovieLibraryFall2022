using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Objects.Media;

public abstract class Media : IMedia
{
    public int Id { get; set; }

    private readonly string? _title;
    
    public string? Title
    {
        get => _title;
        protected init => _title = value ?? throw new ArgumentNullException(nameof(value));
    }
    public abstract string Display();
    public string? GetTitle()
    {
        return _title;
    }
}