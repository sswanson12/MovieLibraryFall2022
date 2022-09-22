using Microsoft.Extensions.Logging;
using MovieLibrary.Objects;
using MovieLibrary.Services.TranslatorServices;

namespace MovieLibrary.Services.DataServices;

public class FileService : IDataService
{
    private readonly string _filePath;
    private readonly ILogger<IDataService> _logger;
    private readonly ITranslatorService _translator;

    public FileService(ILogger<IDataService> logger, ITranslatorService translator)
    {
        //The one hardcoded value. Its okay since it only applies to this specific DataService anyways.
        _filePath = "movies.csv";
        _logger = logger;
        _translator = translator;
    }

    public void Read(ILibrary library)
    {
        _logger.Log(LogLevel.Information, "Reading to movie library");

        var libraryList = library.GetLibrary();
        
        var sr = new StreamReader(_filePath);
        
        sr.ReadLine(); //Skips the header of the file.

        while (!sr.EndOfStream)
        {
            var currentLine = sr.ReadLine() ?? throw new InvalidOperationException();

            libraryList.Add(_translator.FromCsv(currentLine));
        }

        sr.Close();
    }

    public void Write(ILibrary library)
    {
        _logger.Log(LogLevel.Information, "Writing Movie Library");

        var sw = new StreamWriter(_filePath);

        var libraryList = library.GetLibrary();
        
        sw.Write("Movie ID,Movie Title (Release),Genres");

        foreach (var movie in libraryList)
        {
            sw.Write($"\n{_translator.ToCsv(movie)}");
        }

        sw.Close();
    }
}