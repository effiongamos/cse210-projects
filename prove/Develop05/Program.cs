using System;
using System.Collections.Generic;
using System.Threading;

/*
 * Name: Benjamin Amos Effiong
 * Instructor: John Reading
 * Project: Mindfulness program
 * Description: A mindfulness program providing structured breathing, 
   reflection, and listing activities. Exceeds requirements by tracking 
   activity counts and providing enhanced animations.
 */

class MindfulnessActivity
 {
      protected int duration;

    public virtual void StartActivity(string activityName, string description)
    {
        Console.WriteLine($"Starting {activityName}");
        Console.WriteLine(description);
        Console.WriteLine("How long do you want the activity to last (in seconds)?");
        SetDuration();
        Console.WriteLine("Prepare to begin...");
        PauseWithAnimation(3);
    }

    public void EndActivity(String activityName)
    {
        Console.WriteLine($"You have completed the {activityName} activity for {duration} seconds. Great Job!");
        PauseWithAnimation(2);
    }
    protected void SetDuration()
    {
        duration = int.Parse(Console.ReadLine());
    }

    protected void PauseWithAnimation(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
 }

class BreathingActivity : MindfulnessActivity
{
    public override void StartActivity(string activityName, string description)
    {
        base.StartActivity("Breathing", "This activity will help you relax by guiding you through breathing exercises. Clear your mind and focus on your breathing");
        for (int i = 0; i < duration / 2; i++)
        {
            Console.WriteLine("Breathe in...");
            PauseWithAnimation(3);
            Console.WriteLine("Breathe out...");
            PauseWithAnimation(3);
        }
        base.EndActivity("Breathing");
    }
}

class ReflectionActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string> {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need."
    };

    private List<string> questions = new List<string> {
        "Why was this experience meaningful to you?",
        "How did you get started?",
        "How did you feel when it was complete?"
    };

    public override void StartActivity(string activityName, string description)
    {
        base.StartActivity("Reflection", "This activity will help you reflect on times in your life when you have shown strength. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine(prompt);
        PauseWithAnimation(3);

        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < duration)
        {
            string question = questions[random.Next(questions.Count)];
            Console.WriteLine(question);
            PauseWithAnimation(5);
        }
        base.EndActivity("Reflection");
    }
}

class ListingActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string> {
        "List people you appreciate.",
        "List your personal strengths.",
        "List people you helped this week."
    };

    public override void StartActivity(string activityName, string description)
    {
        base.StartActivity("Listing", "This activity helps you list things in your life that are positive.");
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine(prompt);
        PauseWithAnimation(3);

        int itemCount = 0;
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < duration)
        {
            Console.WriteLine("Enter an item:");
            Console.ReadLine();
            itemCount++;
        }
        Console.WriteLine($"You listed {itemCount} items.");
        base.EndActivity("Listing");
    }
}
/*
 * Additional activity in Mindfulness Program
*/

class GratitudeActivity : MindfulnessActivity
{
    private List<string> gratitudePrompts = new List<string> {
        "What is something good that happened to you today?",
        "Who is someone you appreciate in your life?",
        "What is something you are looking forward to?",
        "What is a lesson you learned from a difficult situation?",
        "What is a small thing you enjoyed recently?"
    };

    public override void StartActivity(string activityName, string description)
    {
        base.StartActivity("Gratitude", "This activity will help you reflect on things you are grateful for.");
        Random random = new Random();
        string prompt = gratitudePrompts[random.Next(gratitudePrompts.Count)];
        Console.WriteLine(prompt);
        PauseWithAnimation(3);

        int itemCount = 0;
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < duration)
        {
            Console.WriteLine("Enter something you are grateful for:");
            Console.ReadLine();
            itemCount++;
        }
        Console.WriteLine($"You expressed gratitude for {itemCount} items.");
        base.EndActivity("Gratitude");
    }
}

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("Please, Choose an activity:");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Listing");
            Console.WriteLine("4. Gratitude");
            Console.WriteLine("5. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.StartActivity("Breathing", "");
                    break;
                case "2":
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.StartActivity("Reflection", "");
                    break;
                case "3":
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.StartActivity("Listing", "");
                    break;
                case "4":
                    GratitudeActivity gratitudeActivity = new GratitudeActivity();
                    gratitudeActivity.StartActivity("Gratitude", "");
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}