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
        Console.WriteLine("=Movie Library Application=" +
                          "\nPress the corresponding key and enter to interact with the menu below" +
                          "\n(1) Read Movies From File" +
                          "\n(2) Write A Movie To File" +
                          "\n(X) Quit");

 
    }

    private void Read()
    {
        
    }

    private void Write()
    {
        
    }
}