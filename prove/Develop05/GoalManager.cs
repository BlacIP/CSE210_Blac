using System;
using System.Collections.Generic;

class GoalManager
{
    private int score;
    private List<Goal> goals;

    public GoalManager()
    {
        score = 0;
        goals = new List<Goal>();
    }

    public void CreateNewGoal()
    {
        Console.WriteLine("Select a goal type:");
        Console.WriteLine("1 Simple goal");
        Console.WriteLine("2 Eternal goal");
        Console.WriteLine("3 Checklist goal");

        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();
        Console.WriteLine();

        Console.Write("Enter the name of your goal: ");
        string name = Console.ReadLine();

        Console.Write("Enter a short description of your goal: ");
        string description = Console.ReadLine();

        Console.Write("Enter the amount of points awarded to this goal: ");
        int points = int.Parse(Console.ReadLine());

        Goal goal;

        switch (choice)
        {
            case "1":
                goal = new SimpleGoal(name, description, points);
                break;
            case "2":
                goal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("Enter how many times this goal needs to be accomplished for a bonus: ");
                int targetCount = int.Parse(Console.ReadLine());

                Console.Write("Enter the bonus for accomplishing it that many times: ");
                int bonusPoints = int.Parse(Console.ReadLine());

                goal = new ChecklistGoal(name, description, points, targetCount, bonusPoints);
                break;
            default:
                Console.WriteLine("Invalid choice. Goal creation canceled.");
                return;
        }

        goals.Add(goal);
        Console.WriteLine("Goal created successfully!");
    }

    public void DisplayGoalsAndScore()
    {
        Console.WriteLine("Goals:");

        if (goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
        }
        else
        {
            for (int i = 0; i < goals.Count; i++)
            {
                Goal goal = goals[i];
                string goalStatus = goal.IsCompleted ? "[X]" : "[ ]";
                Console.WriteLine((i + 1) + ". " + goalStatus + " " + goal.DisplayProgress());
            }
        }

        Console.WriteLine();
        Console.WriteLine("Total Points Earned: " + score);
    }

    public void RecordEvent()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals available. Create a goal first.");
            return;
        }

        Console.WriteLine("Select a goal:");

        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + goals[i].DisplayProgress());
        }

        Console.Write("Enter the number of the goal you accomplished: ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex < 0 || goalIndex >= goals.Count)
        {
            Console.WriteLine("Invalid goal selection. Recording event canceled.");
            return;
        }

        Goal goal = goals[goalIndex];
        goal.RecordAccomplishment();
        score += goal.Points;

        Console.WriteLine("Congratulations! You've earned " + goal.Points + " points for accomplishing the goal.");
    }

    public List<Goal> GetGoals()
    {
        return goals;
    }

    public void SetGoals(List<Goal> goals)
    {
        this.goals = goals;
    }

    public int GetTotalScore()
    {
        return score;
    }
}
