namespace MovieLibrary.Objects;

public class Librarian : ILibrarian
{
    public bool CheckId(Movie movie, List<Movie> library)
    {
        //Returns false if no ID matches in the library.
        return library.Any(existingMovie => movie.Id == existingMovie.Id);
    }
    
    public bool CheckId(Show show, List<Show> library)
    {
        //Returns false if no ID matches in the library.
        return library.Any(existingShow => show.Id == existingShow.Id);
    }
    
    public bool CheckId(Video video, List<Video> library)
    {
        //Returns false if no ID matches in the library.
        return library.Any(existingVideo => video.Id == existingVideo.Id);
    }

    public int IssueId(List<Movie> library)
    {
        var newId = library.Last().Id + 1;

        while (library.Any(existingMovie => newId == existingMovie.Id))
        {
            newId++;
        }
        
        return newId;
    }
    
    public int IssueId(List<Show> library)
    {
        var newId = library.Last().Id + 1;

        while (library.Any(existingShow => newId == existingShow.Id))
        {
            newId++;
        }
        
        return newId;
    }
    
    public int IssueId(List<Video> library)
    {
        var newId = library.Last().Id + 1;

        while (library.Any(existingVideo => newId == existingVideo.Id))
        {
            newId++;
        }
        
        return newId;
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

    public bool SearchGenre(string genre, List<Movie> library, out List<Movie> results)
    {
        //Method will not be accessible from MainService unless I decide to fully implement.
        results = new List<Movie>();

        var resultsFlag = false;
        
        foreach (var movie in from movie in library from existingGenre in movie.Genres where existingGenre.Contains(genre) select movie)
        {
            resultsFlag = true;
            results.Add(movie);
        }

        return resultsFlag;
    }
}