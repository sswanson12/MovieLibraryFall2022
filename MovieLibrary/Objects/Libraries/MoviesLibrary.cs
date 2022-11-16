using MovieLibrary.Objects.Media;

namespace MovieLibrary.Objects.Libraries;

public class MoviesLibrary : Library<Movie>
{
    public MoviesLibrary(ILibrarian librarian)
    {
        _librarian = librarian;
        _library = new List<Movie>();
    }

    public override List<Movie> GetLibrary()
    {
        return _library;
    }

    public override bool AddMedia(Movie media)
    {
        if (_librarian.CheckId(media, _library))
        {
            return false;
        }

        media.Id = _librarian.IssueId(_library);

        _library.Add(media);

        return true;
    }

    public override void Search(string? searchString, List<Media.Media> results)
    {
        _librarian.SearchTitle(searchString, _library, results);
    }

    public override void Empty()
    {
        _library.Clear();
    }
}