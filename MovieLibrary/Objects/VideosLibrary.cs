namespace MovieLibrary.Objects;

public class VideosLibrary : Library<Video>
{
    private readonly ILibrarian _librarian;
    
    private readonly List<Video> _library;
    
    public VideosLibrary(ILibrarian librarian)
    {
        _librarian = librarian;
        _library = new List<Video>();
    }

    public override List<Video> GetLibrary()
    {
        return _library;
    }

    public override bool AddMedia(Video media)
    {
        if (_librarian.CheckId(media, _library))
        {
            return false;
        }

        media.Id = _librarian.IssueId(_library);

        _library.Add(media);

        return true;
    }

    public override void Empty()
    {
        _library.Clear();
    }
}