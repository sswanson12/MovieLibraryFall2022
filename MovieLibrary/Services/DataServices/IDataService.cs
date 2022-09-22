using MovieLibrary.Objects;
using MovieLibrary.Services.TranslatorServices;

namespace MovieLibrary.Services.DataServices;


public interface IDataService
{
    public void Read(ILibrary library);

    public void Write(ILibrary library);
}