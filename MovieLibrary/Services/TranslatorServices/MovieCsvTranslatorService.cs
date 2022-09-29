using MovieLibrary.Objects;
using MovieLibrary.Objects.Media;

namespace MovieLibrary.Services.TranslatorServices;

public class MovieCsvTranslatorService : ITranslatorService<Movie>
{
    public string ToCsv(Movie movie)
    {
        string csvLine = $"{movie.Id},{movie.Title},";

        csvLine = movie.Genres.Aggregate(csvLine, (current, genre) => current + $"{genre}|");

        return csvLine[..^1];
    }

    public Movie FromCsv(string movieString)
    {
        string?[] lineSplitUp = movieString.Split(',');

        var genresSplitUp = lineSplitUp[2]?.Split('|');

        var genresList = new List<string>();

        if (genresSplitUp != null)
            foreach (var genre in genresSplitUp)
                genresList.Add(genre);

        return new Movie(Convert.ToInt32(lineSplitUp[0]), lineSplitUp[1], genresList);
    }
}