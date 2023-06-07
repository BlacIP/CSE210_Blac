using System;

// Main program
class Program
{
    public static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.WriteLine("Enter your choice (1-4):");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                if (choice == 4)
                {
                    exit = true;
                    Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
                    continue;
                }

                Console.WriteLine("How long in seconds would you like for your session:");
                int duration = int.Parse(Console.ReadLine());

                Activity activity = null;

                switch (choice)
                {
                    case 1:
                        activity = new BreathingActivity(duration);
                        break;
                    case 2:
                        activity = new ReflectionActivity(duration);
                        break;
                    case 3:
                        activity = new ListingActivity(duration);
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        continue;
                }

                if (activity != null)
                {
                    activity.Start();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            else
            {
                Console.WriteLine("Invalid choice!");
            }
        }
    }
}
