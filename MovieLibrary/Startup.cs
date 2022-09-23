using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MovieLibrary.Objects;
using MovieLibrary.Services;
using MovieLibrary.Services.DataServices;
using MovieLibrary.Services.TranslatorServices;

namespace MovieLibrary;

internal static class Startup
{
    public static IServiceProvider ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddLogging(builder =>
        {
            builder.AddConsole();
            builder.AddFile("app.log");
        });
        
        services.AddSingleton<IMainService, MainService>();
        services.AddSingleton<ITranslatorService, CsvTranslatorService>();
        services.AddSingleton<IDataService, FileService>();
        services.AddSingleton<ILibrary, Library>();
        services.AddSingleton<ILibrarian, Librarian>();

        return services.BuildServiceProvider();
    }
}