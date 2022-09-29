using MovieLibrary.Objects.Media;

namespace MovieLibrary.Services.TranslatorServices;

public class VideoCsvTranslatorService : ITranslatorService<Video>
{
    public Video FromCsv(string mediaString)
    {
        string?[] lineSplitUp = mediaString.Split(',');

        var regionsSplitUp = lineSplitUp[4].Split('|');

        var regionsIntArray = new int[regionsSplitUp.Length];

        for (var i = regionsSplitUp.Length; i > 0; i--)
        {
            regionsIntArray[i] = Convert.ToInt32(regionsSplitUp[i]);
        }

        return new Video(Convert.ToInt32(lineSplitUp[0]), lineSplitUp[1], lineSplitUp[2],
            Convert.ToInt32(lineSplitUp[3]), regionsIntArray);
    }

    public string ToCsv(Video video)
    {
        var csvLine = $"{video.Id},{video.Title},{video.Format},{video.Length},";

        csvLine = video.Regions.Aggregate(csvLine, (current, region) => current + $"{region}|");

        return csvLine[..^1];
    }
}