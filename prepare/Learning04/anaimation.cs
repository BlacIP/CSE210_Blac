using System;
using System.Threading;

public static class DisplayAnimations
{
    public static void DisplaySpinner()
    {
        string[] spinnerFrames = { "/", "-", "\\", "|" };

        for (int i = 0; i < 10; i++)
        {
            Console.Write($"\r{spinnerFrames[i % spinnerFrames.Length]}");
            Thread.Sleep(100); // Adjust the delay as desired
        }
    }

    public static void DisplayCountdown(int seconds)
    {
        for (int i = seconds; i >= 0; i--)
        {
            Console.Write($"\rCountdown: {i} seconds remaining");
            Thread.Sleep(1000); // Adjust the delay as desired
        }
    }

    public static void DisplayProgressBar(int total, int current)
    {
        int progress = (int)((double)current / total * 100);
        Console.Write($"\rProgress: [{new string('#', progress)}{new string('-', 100 - progress)}] {progress}%");
        Thread.Sleep(100); // Adjust the delay as desired
    }

    public static void DisplayDots(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Console.Write(".");
            Thread.Sleep(500); // Adjust the delay as desired
        }
    }

    public static void DisplayGrowingText(string text)
    {
        for (int i = 1; i <= text.Length; i++)
        {
            Console.Write($"\r{text.Substring(0, i)}");
            Thread.Sleep(100); // Adjust the delay as desired
        }
    }
}
