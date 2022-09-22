using System.Xml;
using MovieLibrary.Objects;
using MovieLibrary.Services.DataServices;

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
                          "\n(X) Quit");

        var userInput = Console.ReadLine()?.ToUpper();
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
                case "X":
                    persist = false;
                    break;
            }

            Console.WriteLine("Would you like to continue?" +
                              "\n(1) Read Movies From File" +
                              "\n(2) Write A Movie To File" +
                              "\n(X) QUit");

            userInput = Console.ReadLine()?.ToUpper();

        } while (persist);
    }

    private void Read()
    {
        _dataService.Read(_library);
        
        for (int i = 0; i < 25; i++)
        {
            Console.WriteLine(_library.GetLibrary()[i].ToString());
        }
    }

    private void Write()
    {
        _library.AddMedia(CreateMovie());

        _dataService.Write(_library);
        
        _library.Empty();
    }

    private Movie CreateMovie()
    {
        
    }
}