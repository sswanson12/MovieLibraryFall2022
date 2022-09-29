using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MovieLibrary.Objects;
using MovieLibrary.Objects.Libraries;
using MovieLibrary.Objects.Media;
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
        services.AddSingleton<ITranslatorService<Movie>, MovieCsvTranslatorService>();
        services.AddSingleton<ITranslatorService<Show>, ShowCsvTranslatorService>();
        services.AddSingleton<ITranslatorService<Video>, VideoCsvTranslatorService>();
        services.AddSingleton<IDataService, FileService>();
        services.AddSingleton<ILibrary<Movie>, MoviesLibrary>();
        services.AddSingleton<ILibrary<Show>, ShowsLibrary>();
        services.AddSingleton<ILibrary<Video>, VideosLibrary>();
        services.AddSingleton<IMediaCreator, MediaCreator>();
        services.AddSingleton<ILibrarian, Librarian>();

        return services.BuildServiceProvider();
    }
}