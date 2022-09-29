using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Objects.Media;

public abstract class Media : IMedia
{
    public abstract string Display();
}