using MovieLibrary.Objects.Media;

namespace MovieLibrary.Objects;

public interface ILibrarian
{
    //Sees if ID already exists in library
    bool CheckId(Movie movie, List<Movie> library);
    
    bool CheckId(Show show, List<Show> library);
    
    bool CheckId(Video video, List<Video> library);

    int IssueId(List<Movie> library);
    
    int IssueId(List<Show> library);
    
    int IssueId(List<Video> library);
    
    bool SearchTitle(string title, List<Movie?> library, out Movie? result);
    
    bool SearchGenre(string genre, List<Movie> library, out List<Movie> results);
}