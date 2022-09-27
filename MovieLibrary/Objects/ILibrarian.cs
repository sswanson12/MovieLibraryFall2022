namespace MovieLibrary.Objects;

public interface ILibrarian
{
    //Sees if ID already exists in library
    bool CheckId(Movie movie, List<Movie> library);

    int IssueId(List<Movie> library);
    
    bool SearchTitle(string title, List<Movie?> library, out Movie? result);
    
    bool SearchGenre(string genre, List<Movie> library, out List<Movie> results);
}