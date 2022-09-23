using Microsoft.Extensions.DependencyInjection;
using MovieLibrary;
using MovieLibrary.Services;

try
{
    var serviceProvider = Startup.ConfigureServices();
    var service = serviceProvider.GetService<IMainService>();

    service?.Invoke();
}
catch (Exception e)
{
    Console.Error.WriteLine(e);
}