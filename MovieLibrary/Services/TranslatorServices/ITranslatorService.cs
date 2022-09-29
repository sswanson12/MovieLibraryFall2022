using MovieLibrary.Objects;
using MovieLibrary.Objects.Media;

namespace MovieLibrary.Services.TranslatorServices;

public interface ITranslatorService<T>
{
    public T FromCsv(string mediaString);
    
    public string ToCsv(T movie);
}