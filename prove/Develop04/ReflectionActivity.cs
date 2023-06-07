using System;
using System.Threading;

// Derived class for reflection activity
public class ReflectionActivity : Activity
{
    private static readonly string[] prompts = {
        "---Think of a time when you stood up for someone else.---",
        "---Think of a time when you did something really difficult.---",
        "---Think of a time when you helped someone in need.---",
        "---Think of a time when you did something truly selfless.---"
    };

    private static readonly string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(int duration) : base(duration)
    {
    }

    public override void Start()
    {
        DisplayStartingMessage("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

        Random random = new Random();

        for (int i = 0; i < duration; i++)
    {
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(prompt);DisplayPauseAnimation();
        Console.WriteLine("Did you think of something yet? Press Enter to continue...");DisplayPauseAnimation();
        Console.ReadLine(); // Wait for Enter key press

        Console.WriteLine("Ponder on the following question:");
        Console.WriteLine("Get ready to begin in:");

        for (int countdown = 5; countdown > 0; countdown--)
        {
            Console.Write(countdown);
            Thread.Sleep(1000); // Pause for 1 second
            Console.Write("\b \b");
        }

        foreach (string question in questions)
        {
            Console.WriteLine(question);
            Thread.Sleep(2000); // Pause for 2 seconds
            DisplayPauseAnimation();
        }
        }

        DisplayEndingMessage("Reflection Activity");
    }
}
