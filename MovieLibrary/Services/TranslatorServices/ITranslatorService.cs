using MovieLibrary.Objects;

namespace MovieLibrary.Services.TranslatorServices;

public interface ITranslatorService
{
    public string ToCsv(Movie movie);

    public Movie FromCsv(string movieString);
}