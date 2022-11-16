using MovieLibrary.Objects.Media;

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

    public void SearchTitle(string? searchTitle, List<Movie> library, List<Media.Media> results)
    {
        results.AddRange(library.Where(media => searchTitle != null && media.Title != null && media.Title.Contains(searchTitle, StringComparison.OrdinalIgnoreCase)));
    }

    public void SearchTitle(string? searchTitle, List<Show> library, List<Media.Media> results)
    {
        results.AddRange(library.Where(media => searchTitle != null && media.Title != null && media.Title.Contains(searchTitle, StringComparison.OrdinalIgnoreCase)));
    }

    public void SearchTitle(string? searchTitle, List<Video> library, List<Media.Media> results)
    {
        results.AddRange(library.Where(media => searchTitle != null && media.Title != null && media.Title.Contains(searchTitle, StringComparison.OrdinalIgnoreCase)));
    }
}