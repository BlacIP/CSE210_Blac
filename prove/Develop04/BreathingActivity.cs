using System;

// Derived class for breathing activity
public class BreathingActivity : Activity
{
    public BreathingActivity(int duration, string userName) : base(duration, userName)
    {
    }

    public override void Start()
    {
        DisplayStartingMessage("Welcome to Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        

        for (int i = 0; i < duration; i++)
        {
            Console.WriteLine("Breathe in...");
            DisplayPauseAnimation();

            Console.WriteLine("...Now Breathe out");
            DisplayPauseAnimation();
        }

        DisplayEndingMessage("Breathing Activity");
    }
}
