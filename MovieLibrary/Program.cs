using Microsoft.Extensions.DependencyInjection;
using MovieLibrary;
using MovieLibrary.Services;

try
{
    var startup = new Startup();
    var serviceProvider = startup.ConfigureServices();
    var service = serviceProvider.GetService<IMainService>();

    service?.Invoke();
}
catch (Exception e)
{
    Console.Error.WriteLine(e);
}