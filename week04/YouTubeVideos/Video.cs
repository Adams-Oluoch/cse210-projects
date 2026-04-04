using System;
using System.Collections.Generic;

public class Video
{
    
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }

    
    private readonly List<Comment> _comments = new();

    
    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
    }

    
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    
    public List<Comment> GetComments()
    {
        return _comments;
    }
}