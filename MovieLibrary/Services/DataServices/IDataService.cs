using MovieLibrary.Objects;
using MovieLibrary.Objects.Libraries;
using MovieLibrary.Objects.Media;
using MovieLibrary.Services.TranslatorServices;

namespace MovieLibrary.Services.DataServices;


public interface IDataService
{
    public void Read(ILibrary<Movie> library);

    public void Write(ILibrary<Movie> library);
    
    public void Read(ILibrary<Video> library);

    public void Write(ILibrary<Video> library);
    
    public void Read(ILibrary<Show> library);

    public void Write(ILibrary<Show> library);
}