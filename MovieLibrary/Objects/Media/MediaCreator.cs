namespace MovieLibrary.Objects.Media;
using static System.Int32;

public class MediaCreator : IMediaCreator
{
    public Movie CreateMovie()
    {
        var genreList = new List<string>();
        
        
        Console.Write("Please enter the year the movie was released: ");
        int releaseYear;
            
        while (!TryParse(Convert.ToString(Console.ReadLine()), out releaseYear))
        {
            Console.WriteLine("Only numbers are allowed. Please try again.");
        }

        Console.Write("Please enter the movie title: ");
        var newTitle = Convert.ToString(Console.ReadLine());

        while (newTitle is {Length: <= 0})
        {
            Console.Write("Looks like you left the title blank! Please try again: ");
            newTitle = Convert.ToString(Console.ReadLine());
        }

        newTitle = $"{newTitle} ({releaseYear})";

        Console.Write("Please enter all the movie's genres (when done entering, enter (x) to exit): ");

        while (true)
        {
            var currentGenre = Convert.ToString(Console.ReadLine());
            while (currentGenre is null)
            {
                Console.Write("Looks like you left a blank genre! Please try again: ");
                currentGenre = Convert.ToString(Console.ReadLine());
            }

            if (currentGenre.ToLower().Equals("x")) break;

            genreList.Add(currentGenre);
        }

        return new Movie(-1 /*If a movie has id of -1 in file, obvious error*/, newTitle, genreList);
    }

    public Show CreateShow()
    {
        Console.Write("Please enter the year the show was released: ");
        var releaseYear = Convert.ToString(Console.ReadLine());

        Console.Write("Please enter the movie title: ");
        var newTitle = Convert.ToString(Console.ReadLine());

        while (newTitle is {Length: <= 0})
        {
            Console.Write("Looks like you left the title blank! Please try again: ");
            newTitle = Convert.ToString(Console.ReadLine());
        }

        newTitle = $"{newTitle} ({releaseYear})";

        Console.Write("Please enter which season the episode is from: ");
        var season = Convert.ToInt32(Console.ReadLine());

        Console.Write("Please enter the episode number: ");
        var episode = Convert.ToInt32(Console.ReadLine());

        Console.Write("How many writers does this show have? ");
        var numWriters = Convert.ToInt32(Console.ReadLine());
        var writers = new string?[numWriters];
        for (var i = 0; i < numWriters; i++)
        {
            Console.Write($"Please enter writer {i+1}: ");
            writers[i] = Console.ReadLine();
        }

        return new Show(-1, newTitle, season, episode, writers);
    }

    public Video CreateVideo()
    {
        Console.Write("Please enter the year the video was released: ");
        var releaseYear = Convert.ToString(Console.ReadLine());

        Console.Write("Please enter the movie title: ");
        var newTitle = Convert.ToString(Console.ReadLine());

        while (newTitle is {Length: <= 0})
        {
            Console.Write("Looks like you left the title blank! Please try again: ");
            newTitle = Convert.ToString(Console.ReadLine());
        }

        newTitle = $"{newTitle} ({releaseYear})";

        Console.Write("Please enter what format the video is in: ");
        var format = Convert.ToString(Console.ReadLine());

        Console.Write("Please enter the length of the video in minutes: ");
        var length = Convert.ToInt32(Console.ReadLine());

        Console.Write("How many regions is this video available in? ");
        var numRegions = Convert.ToInt32(Console.ReadLine());
        var regions = new int[numRegions];
        for (var i = 0; i < numRegions; i++)
        {
            Console.Write($"Please enter region {i+1}: ");
            regions[i] = Convert.ToInt32(Console.ReadLine());
        }

        return new Video(-1, newTitle, format, length, regions);
    }
}