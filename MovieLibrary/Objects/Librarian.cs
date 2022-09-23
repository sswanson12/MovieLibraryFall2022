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
    
    public bool SearchTitle(string title, List<Movie?> library, out Movie? result)
    {
        //Method will not be accessible from MainService until needed.

        foreach (var movie in library.Where(movie => movie?.Title != null && movie.Title.Contains(title)))
        {
            result = movie;
            return true;
        }

        result = null;
        return false;
    }

    public List<Movie> SearchGenre(string genre, List<Movie> library)
    {
        //Method will not be accessible unless I actually decide to implement it on top of the assignment.
        throw new NotImplementedException();
    }
}