﻿namespace MovieLibrary.Objects.Libraries;

public interface ILibrary<T>
{
    List<T> GetLibrary();

    bool AddMedia(T media); 

    void Empty();
}