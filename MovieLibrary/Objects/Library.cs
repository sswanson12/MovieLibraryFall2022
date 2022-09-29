namespace MovieLibrary.Objects;

public abstract class Library<T> : ILibrary<T>
{
    public abstract List<T> GetLibrary();

    public abstract bool AddMedia(T media);

    public abstract void Empty();
}