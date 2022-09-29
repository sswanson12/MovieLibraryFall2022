using MovieLibrary.Objects.Libraries;
using MovieLibrary.Objects.Media;
using MovieLibrary.Services.DataServices;
using static System.Int32;

namespace MovieLibrary.Services;

public class MainService : IMainService
{
    private readonly IDataService _dataService;
    private readonly ILibrary<Movie> _movieLibrary;
    private readonly ILibrary<Show> _showLibrary;
    private readonly ILibrary<Video> _videoLibrary;
    private readonly IMediaCreator _mediaCreator;

    public MainService(IDataService dataService, ILibrary<Movie> movieLibrary, ILibrary<Show> showLibrary, ILibrary<Video> videoLibrary, IMediaCreator mediaCreator)
    {
        _dataService = dataService;
        _movieLibrary = movieLibrary;
        _showLibrary = showLibrary;
        _videoLibrary = videoLibrary;
        _mediaCreator = mediaCreator;
    }

    public void Invoke()
    {
        Console.WriteLine("=Movie Library=" +
                          "\nPress the corresponding key and enter to interact with the menu below" +
                          "\n(1) Read Movies From File" +
                          "\n(2) Write A Movie To File" +
                          "\n(x) Quit");

        var userInput = Console.ReadLine()?.ToLower();
        var persist = true;

        do
        {
            switch (userInput)
            {
                case "1":
                    Read();
                    break;
                case "2":
                    Write();
                    break;
                case "x":
                    persist = false;
                    break;
            }

            Console.WriteLine("Would you like to continue?" +
                              "\n(1) Read Movies From File" +
                              "\n(2) Write A Movie To File" +
                              "\n(x) QUit");

            userInput = Console.ReadLine()?.ToLower();

            if (userInput is "x")
            {
                persist = false;
            }

        } while (persist);
    }

    private void Read()
    {
        _dataService.Read(_movieLibrary);

        for (int i = 0; i < 25; i++)
        {
            Console.WriteLine(_movieLibrary.GetLibrary()[i].Display());
        }
        
        _movieLibrary.Empty();
    }

    private void Write()
    {
        _dataService.Read(_movieLibrary);

        while (!_movieLibrary.AddMedia(_mediaCreator.CreateMovie()))
        {
            Console.WriteLine("A movie with this ID already exists in the library. Please try again.");
        }

        _dataService.Write(_movieLibrary);

        _movieLibrary.Empty();
    }
}