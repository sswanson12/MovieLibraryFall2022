using MovieLibrary.Objects.Media;

namespace MovieLibrary.Objects.Libraries;

public abstract class Library<T> : ILibrary<T>
{
    protected ILibrarian _librarian;
    
    protected List<T> _library;
    
    public abstract List<T> GetLibrary();

    public abstract bool AddMedia(T media);

    public abstract void Search(string? searchString, List<Media.Media> results);

    public abstract void Empty();
}