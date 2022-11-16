using MovieLibrary.Objects.Media;

namespace MovieLibrary.Objects.Libraries;

public interface ILibrary<T>
{
    List<T> GetLibrary();

    bool AddMedia(T media);

    void Search(string? searchString, List<Media.Media> results);

    void Empty();
}