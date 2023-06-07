using System;
using System.Threading;

// Derived class for listing activity
public class ListingActivity : Activity
{
    private static readonly string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int duration, string userName) : base(duration, userName)
    {
    }

    public override void Start()
    {
        DisplayStartingMessage("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(prompt);
        Console.WriteLine("You have several seconds to think...");
        Thread.Sleep(5000); // Pause for 5 seconds

        Console.WriteLine("Start listing...");
        Console.WriteLine("Press Enter after each item:");

        int itemCount = 0;
        bool activityEnded = false;

        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (!activityEnded && DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(item))
            {
                activityEnded = true;
            }
            else
            {
                itemCount++;
            }
        }

        Console.WriteLine($"Number of items listed: {itemCount}");
        DisplayEndingMessage("Listing Activity");
    }
}
