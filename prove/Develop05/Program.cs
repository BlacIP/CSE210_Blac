using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        FileHandler fileHandler = new FileHandler();

        Console.WriteLine("Welcome to the Eternal Quest Program!");

        while (true)
        {
            Console.WriteLine("Total Points Earned: " + goalManager.GetTotalScore());
            Console.WriteLine("Select an option:");
            Console.WriteLine("1 Create a new goal");
            Console.WriteLine("2 List goals");
            Console.WriteLine("3 Save goals");
            Console.WriteLine("4 Load goals");
            Console.WriteLine("5 Record an event");
            Console.WriteLine("6 Quit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    goalManager.CreateNewGoal();
                    break;
                case "2":
                    goalManager.DisplayGoalsAndScore();
                    break;
                case "3":
                    fileHandler.SaveGoals(goalManager.GetGoals(), goalManager.GetTotalScore());
                    break;
                case "4":
                    goalManager.SetGoals(fileHandler.LoadGoals());
                    break;
                case "5":
                    goalManager.RecordEvent();
                    break;
                case "6":
                    Console.WriteLine("Thank you for using the Eternal Quest Program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
