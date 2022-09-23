namespace MovieLibrary.Objects;

public class Librarian : ILibrarian
{
    public bool CheckId(Movie movie, List<Movie> library)
    {
        //Returns false if no ID matches in the library.
        return library.Any(existingMovie => movie.Id == existingMovie.Id);
    }

    public int IssueId(List<Movie> library)
    {
        var newId = library.Last().Id + 1;

        while (library.All(existingMovie => newId != existingMovie.Id))
        {
            newId++;
        }
        
        return newId;
        //return library.Last().Id + 1;
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