using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
       
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("Eagles Hunting in Mountains", "Wildlife World", 1080);
        video1.AddComment(new Comment("Roger", "Incredible footage!"));
        video1.AddComment(new Comment("Pat", "Nature is amazing."));
        video1.AddComment(new Comment("Sandra", "The slow motion shots are epic."));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Coral Reef Documentary", "Ocean Explorers", 2400);
        video2.AddComment(new Comment("Derek", "So colorful and peaceful."));
        video2.AddComment(new Comment("Wendy", "We need to protect our oceans."));
        video2.AddComment(new Comment("Bruce", "Best underwater content I've seen."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Baby Panda Compilation", "Cute Animal Clips", 180);
        video3.AddComment(new Comment("Julie", "My heart can't handle this!"));
        video3.AddComment(new Comment("Peter", "Watched this five times already."));
        video3.AddComment(new Comment("Nancy", "Shared with everyone I know."));
        videos.Add(video3);

        // Video 4
        Video video4 = new Video("Migration of Monarch Butterflies", "Nature Narratives", 1500);
        video4.AddComment(new Comment("Carl", "What a journey they make."));
        video4.AddComment(new Comment("Beth", "Beautiful cinematography."));
        video4.AddComment(new Comment("Frank", "Learned so much from this."));
        videos.Add(video4);

        // Display all videos
        foreach (Video video in videos)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine(); 
        }

        Console.WriteLine("Press any key to exit...");
    }
}S