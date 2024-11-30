using System;
using System.Collections.Generic;

namespace VideoCommentsApp
{
    public class Comment
    {
        public string Name { get; set; }
        public string Text { get; set; }

        public Comment(string name, string text)
        {
            Name = name;
            Text = text;
        }
    }

    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Length { get; set; }
        public List<Comment> Comments { get; set; }

        public Video(string title, string author, int length)
        {
            Title = title;
            Author = author;
            Length = length;
            Comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public int GetCommentCount()
        {
            return Comments.Count;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Create video objects
            Video video1 = new Video("How to Code in C#", "John Doe", 600);
            Video video2 = new Video("10 Tips for JavaScript", "Jane Smith", 450);
            Video video3 = new Video("Understanding OOP", "Alex Brown", 720);

            // Add comments to video1
            video1.AddComment(new Comment("Alice", "Great explanation!"));
            video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
            video1.AddComment(new Comment("Charlie", "Clear and concise."));

            // Add comments to video2
            video2.AddComment(new Comment("Diana", "Loved the tips!"));
            video2.AddComment(new Comment("Eve", "Tip #4 was a lifesaver!"));
            video2.AddComment(new Comment("Frank", "Can you make a follow-up video?"));

            // Add comments to video3
            video3.AddComment(new Comment("Grace", "Very detailed tutorial."));
            video3.AddComment(new Comment("Hank", "I learned so much from this!"));
            video3.AddComment(new Comment("Ivy", "Perfect for beginners."));

            // Store videos in a list
            List<Video> videos = new List<Video> { video1, video2, video3 };

            // Display video details and comments
            foreach (var video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.Length} seconds");
                Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
                Console.WriteLine("Comments:");
                foreach (var comment in video.Comments)
                {
                    Console.WriteLine($"- {comment.Name}: {comment.Text}");
                }
                Console.WriteLine(); // Blank line for better readability
            }
        }
    }
}
