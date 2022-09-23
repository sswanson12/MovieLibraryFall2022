namespace MovieLibrary.Objects;

public interface ILibrarian
{
    //Sees if ID already exists in library
    bool CheckId(Movie movie, List<Movie> library);

    int IssueId(List<Movie> library);

    //Ask Mark about that thing where you can return two types to return if the movie exists, and return the movie
    //This doesn't need to be implemented until the abstract assignment. But that is due next week so I'll implement
    //this method then.
    
    //Discovered the answer to the question when going to use the Int32.TryParse() method!
    bool SearchTitle(string title, List<Movie?> library, out Movie? result);

    //This also will not be implemented yet, however I think this would be something fun to do as a little extra.
    //I could search for whatever movies are in a specific genre, and return that list to be displayed.
    //String.Contains() method might be handy for this!
    List<Movie> SearchGenre(string genre, List<Movie> library);
}