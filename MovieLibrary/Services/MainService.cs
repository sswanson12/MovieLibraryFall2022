using System.Xml;
using MovieLibrary.Objects;
using MovieLibrary.Services.DataServices;
using static System.Int32;

namespace MovieLibrary.Services;

public class MainService : IMainService
{
    private readonly IDataService _dataService;
    private readonly ILibrary _library;

    public MainService(IDataService dataService, ILibrary library)
    {
        _dataService = dataService;
        _library = library;
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

            if (userInput != null && userInput.Equals("x"))
            {
                persist = false;
            }

        } while (persist);
    }

    private void Read()
    {
        _dataService.Read(_library);

        for (int i = 0; i < 25; i++)
        {
            Console.WriteLine(_library.GetLibrary()[i].ToString());
        }
        
        _library.Empty();
    }

    private void Write()
    {
        _dataService.Read(_library);
        
        CreateMovie();

        _dataService.Write(_library);

        _library.Empty();
    }

    private void CreateMovie()
    {
        int id;
        string? newTitle;
        var genreList = new List<string>();

        do
        {
            Console.Write("Please enter the year the movie was released: ");
            int releaseYear;
            
            while (!TryParse(Convert.ToString(Console.ReadLine()), out releaseYear))
            {
                Console.WriteLine("Only numbers are allowed. Please try again.");
            }

            Console.Write("Please enter the movie title: ");
            newTitle = Convert.ToString(Console.ReadLine());

            while (newTitle is {Length: <= 0})
            {
                Console.Write("Looks like you left the title blank! Please try again: ");
                newTitle = Convert.ToString(Console.ReadLine());
            }

            newTitle = $"{newTitle} ({releaseYear})";

            Console.Write("Please enter all the movie's genres (when done entering, enter (x) to exit): ");

            while (true)
            {
                var currentGenre = Convert.ToString(Console.ReadLine());
                while (currentGenre is null)
                {
                    Console.Write("Looks like you left a blank genre! Please try again: ");
                    currentGenre = Convert.ToString(Console.ReadLine());
                }

                if (currentGenre.ToLower().Equals("x")) break;

                genreList.Add(currentGenre);
            }
        } while (!_library.AddMedia(new Movie(-1, newTitle, genreList)));
    }
}