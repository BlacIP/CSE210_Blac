using System;
using System.Threading;

// Base class for activities
public abstract class Activity
{
    protected int duration; // Duration of the activity in seconds
    protected string userName; // User's name

    public Activity(int duration, string userName)
    {
        this.duration = duration;
        this.userName = userName;
    }

    // Method to display the starting message
    protected virtual void DisplayStartingMessage(string activityName, string description)
    {
        Console.WriteLine($"--- {activityName} ---");
        Console.WriteLine(description);
        Console.WriteLine($"Welcome, {userName}!");
        Console.WriteLine("Get ready to begin...");DisplayPauseAnimation();
        Thread.Sleep(1500); // Pause for 1seconds 500 milliseconds
    }

    // Method to display the ending message
    protected virtual void DisplayEndingMessage(string activityName)
    {
        Console.WriteLine($"Good job!, {userName}");
        Console.WriteLine($"You have completed the {activityName} activity in {duration} seconds");
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    // Method to display animation during pauses
    protected virtual void DisplayPauseAnimation()
    {
        string[] spinnerFrames = { "|", "/", "-", "\\", "|", "/", "-", "\\" };
        

        for (int i = 0; i < spinnerFrames.Length; i++)
        {
            Console.Write(spinnerFrames[i]);
            Thread.Sleep(1500); // Delay for 1seconds 500 milliseconds
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop); // Move cursor back
        }
    }

    // Method to start the activity
    public abstract void Start();
}
