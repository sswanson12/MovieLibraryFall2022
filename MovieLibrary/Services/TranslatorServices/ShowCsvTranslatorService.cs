using MovieLibrary.Objects.Media;

namespace MovieLibrary.Services.TranslatorServices;

public class ShowCsvTranslatorService : ITranslatorService<Show>
{
    public Show FromCsv(string mediaString)
    {
        var lineSplitUp = mediaString.Split(',');

        string?[] writersSplitUp = lineSplitUp[4].Split('|');

        return new Show(Convert.ToInt32(lineSplitUp[0]), lineSplitUp[1], Convert.ToInt32(lineSplitUp[2]),
            Convert.ToInt32(lineSplitUp[3]), writersSplitUp);
    }

    public string ToCsv(Show show)
    {
        string csvLine = $"{show.Id},{show.Title},{show.Season},{show.Episode},";

        csvLine = show.Writers.Aggregate(csvLine, (current, writer) => current + $"{writer}|");

        return csvLine[..^1];
    }
}