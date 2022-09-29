using Microsoft.Extensions.Logging;
using MovieLibrary.Objects;
using MovieLibrary.Objects.Libraries;
using MovieLibrary.Objects.Media;
using MovieLibrary.Services.TranslatorServices;

namespace MovieLibrary.Services.DataServices;

public class FileService : IDataService
{
    private readonly string _moviePath;
    private readonly string _showPath;
    private readonly string _videoPath;
    private readonly ILogger<IDataService> _logger;
    private readonly ITranslatorService<Movie> _movieTranslator;
    private readonly ITranslatorService<Show> _showTranslator;
    private readonly ITranslatorService<Video> _videoTranslator;

    public FileService(ILogger<IDataService> logger, ITranslatorService<Movie> movieTranslator, ITranslatorService<Show> showTranslator, ITranslatorService<Video> videoTranslator)
    {
        //The one hardcoded value. Its okay since it only applies to this specific DataService anyways.
        _moviePath = "movies.csv";
        _showPath = "shows.csv";
        _videoPath = "videos.csv";
        _logger = logger;
        _movieTranslator = movieTranslator;
        _showTranslator = showTranslator;
        _videoTranslator = videoTranslator;
    }

    public void Read(ILibrary<Movie> library)
    {
        _logger.Log(LogLevel.Information, "Reading to movie library");

        var libraryList = library.GetLibrary();
        
        var sr = new StreamReader(_moviePath);
        
        sr.ReadLine(); //Skips the header of the file.

        while (!sr.EndOfStream)
        {
            var currentLine = sr.ReadLine() ?? throw new InvalidOperationException();

            libraryList.Add(_movieTranslator.FromCsv(currentLine));
        }

        sr.Close();
    }

    public void Write(ILibrary<Movie> library)
    {
        _logger.Log(LogLevel.Information, "Writing movie library to file");

        var sw = new StreamWriter(_moviePath);

        var libraryList = library.GetLibrary();
        
        sw.Write("MovieId,MovieTitle (Release),Genres");

        foreach (var movie in libraryList)
        {
            sw.Write($"\n{_movieTranslator.ToCsv(movie)}");
        }

        sw.Close();
    }

    public void Read(ILibrary<Video> library)
    {
        _logger.Log(LogLevel.Information, "Reading to video library");

        var libraryList = library.GetLibrary();
        
        var sr = new StreamReader(_videoPath);
        
        sr.ReadLine(); //Skips the header of the file.

        while (!sr.EndOfStream)
        {
            var currentLine = sr.ReadLine() ?? throw new InvalidOperationException();

            libraryList.Add(_videoTranslator.FromCsv(currentLine));
        }

        sr.Close();
    }

    public void Write(ILibrary<Video> library)
    {
        _logger.Log(LogLevel.Information, "Writing video library to file");

        var sw = new StreamWriter(_videoPath);

        var libraryList = library.GetLibrary();
        
        sw.Write("VideoId,Title,Format,Length,Regions");

        foreach (var video in libraryList)
        {
            sw.Write($"\n{_videoTranslator.ToCsv(video)}");
        }

        sw.Close();
    }

    public void Read(ILibrary<Show> library)
    {
        _logger.Log(LogLevel.Information, "Reading to show library");

        var libraryList = library.GetLibrary();
        
        var sr = new StreamReader(_showPath);
        
        sr.ReadLine(); //Skips the header of the file.

        while (!sr.EndOfStream)
        {
            var currentLine = sr.ReadLine() ?? throw new InvalidOperationException();

            libraryList.Add(_showTranslator.FromCsv(currentLine));
        }

        sr.Close();
    }

    public void Write(ILibrary<Show> library)
    {
        _logger.Log(LogLevel.Information, "Writing show library to file");

        var sw = new StreamWriter(_showPath);

        var libraryList = library.GetLibrary();
        
        sw.Write("ShowId,Title,Season,Episode,Writers");

        foreach (var show in libraryList)
        {
            sw.Write($"\n{_showTranslator.ToCsv(show)}");
        }

        sw.Close();
    }
}