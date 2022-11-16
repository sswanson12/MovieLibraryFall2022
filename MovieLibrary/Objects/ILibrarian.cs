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
    
    void SearchTitle(string? searchTitle, List<Movie> library, List<Media.Media> results);
    
    void SearchTitle(string? searchTitle, List<Show> library, List<Media.Media> results);
    
    void SearchTitle(string? searchTitle, List<Video> library, List<Media.Media> results);
    
}