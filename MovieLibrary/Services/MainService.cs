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
                          "\n(1) Read Media From Files" +
                          "\n(2) Write Media To File" +
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
                              "\n(1) Read Media From Files" +
                              "\n(2) Write Media To File" +
                              "\n(x) Quit");

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
        
        _dataService.Read(_showLibrary);
        
        _dataService.Read(_videoLibrary);

        Console.WriteLine("---------Movies--------");

        foreach (var movie in _movieLibrary.GetLibrary())
        {
            Console.WriteLine(movie.Display());
        }

        Console.WriteLine("\n--------Shows--------");
        
        foreach (var show in _showLibrary.GetLibrary())
        {
            Console.WriteLine(show.Display());
        }

        Console.WriteLine("\n---------Videos--------");
        
        foreach (var video in _videoLibrary.GetLibrary())
        {
            Console.WriteLine(video.Display());
        }

        _movieLibrary.Empty();
        
        _showLibrary.Empty();
        
        _videoLibrary.Empty();
    }

    private void Write()
    {
        Console.WriteLine("\nWould you like to:" +
                          "\n(1) Write a movie" +
                          "\n(2) Write a show" +
                          "\n(3) Write a video");

        var repeat = false;
        
        do
        {
            switch (Console.ReadLine())
            {
                case "1":
                    WriteMovie();
                    break;
                case "2":
                    WriteShow();
                    break;
                case "3":
                    WriteVideo();
                    break;
                default:
                    repeat = true;
                    break;
            }
        } while (repeat);
    }

    private void WriteMovie()
    {
        _dataService.Read(_movieLibrary);

        while (!_movieLibrary.AddMedia(_mediaCreator.CreateMovie()))
        {
            Console.WriteLine("A movie with this ID already exists in the library. Please try again.");
        }

        _dataService.Write(_movieLibrary);

        _movieLibrary.Empty();
    }

    private void WriteShow()
    {
        _dataService.Read(_showLibrary);

        while (!_showLibrary.AddMedia(_mediaCreator.CreateShow()))
        {
            Console.WriteLine("A show with this ID already exists in the library. Please try again.");
        }

        _dataService.Write(_showLibrary);

        _showLibrary.Empty();
    }

    private void WriteVideo()
    {
        _dataService.Read(_videoLibrary);

        while (!_videoLibrary.AddMedia(_mediaCreator.CreateVideo()))
        {
            Console.WriteLine("A video with this ID already exists in the library. Please try again.");
        }

        _dataService.Write(_videoLibrary);

        _videoLibrary.Empty();
    }
}