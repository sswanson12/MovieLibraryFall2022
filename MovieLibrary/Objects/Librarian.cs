namespace MovieLibrary.Objects;

public class Librarian : ILibrarian
{
    private ILibrary _library;

    public Librarian(ILibrary library)
    {
        _library = library;
    }
    
    public bool CheckId(Movie movie)
    {
        //Returns false if no ID matches in the library.
        foreach (var existingMovie in _library.GetLibrary())
        {
            if (movie.Id == existingMovie.Id)
            {
                return true;
            }
        }
        
        return false;
    }

    public bool SearchTitle(string title)
    {
        //Method will not be accessible from MainService until needed.
        throw new NotImplementedException();
    }

    public List<Movie> SearchGenre(string genre)
    {
        //Method will not be accessible unless I actually decide to implement it on top of the assignment.
        throw new NotImplementedException();
    }
}