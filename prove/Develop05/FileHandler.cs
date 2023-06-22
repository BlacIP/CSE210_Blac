using System;
using System.Collections.Generic;

class FileHandler
{
    private string currentFileName;

    public void SaveGoals(List<Goal> goals, int score)
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals to save.");
            return;
        }

        Console.Write("Enter the filename for the goal (save as .txt): ");
        string filename = Console.ReadLine();

        try
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename))
            {
                file.WriteLine(score);

                foreach (Goal goal in goals)
                {
                    file.WriteLine(goal.ToFileString());
                }
            }

            Console.WriteLine("Goals saved successfully!");
            currentFileName = filename;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error occurred while saving goals: " + ex.Message);
        }
    }

    public List<Goal> LoadGoals()
    {
        Console.Write("Enter the filename for the goal file: ");
        string filename = Console.ReadLine();

        try
        {
            string[] lines = System.IO.File.ReadAllLines(filename);

            if (lines.Length == 0)
            {
                Console.WriteLine("Invalid goal file format.");
                return new List<Goal>();
            }

            List<Goal> loadedGoals = new List<Goal>();
            int score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] goalData = lines[i].Split(':');
                string goalType = goalData[0];
                string name = goalData[1];
                string description = goalData[2];
                int points = int.Parse(goalData[3]);

                Goal goal;

                switch (goalType)
                {
                    case "Simple":
                        goal = new SimpleGoal(name, description, points);
                        break;
                    case "Eternal":
                        goal = new EternalGoal(name, description, points);
                        break;
                    case "Checklist":
                        int targetCount = int.Parse(goalData[4]);
                        int bonusPoints = int.Parse(goalData[5]);
                        goal = new ChecklistGoal(name, description, points, targetCount, bonusPoints);
                        break;
                    default:
                        Console.WriteLine("Invalid goal type in goal file. Skipping goal.");
                        continue;
                }

                loadedGoals.Add(goal);
            }

            Console.WriteLine("Goals loaded successfully!");
            currentFileName = filename;
            return loadedGoals;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error occurred while loading goals: " + ex.Message);
            return new List<Goal>();
        }
    }
}
