namespace MovieLibrary.Objects.Media;

public interface IMediaCreator
{
    Movie CreateMovie();

    Show CreateShow();

    Video CreateVideo();
}