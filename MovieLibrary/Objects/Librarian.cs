namespace MovieLibrary.Objects;

public class Librarian : ILibrarian
{
    public bool CheckId(Movie movie, List<Movie> library)
    {
        //Returns false if no ID matches in the library.
        return library.Any(existingMovie => movie.Id == existingMovie.Id);
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