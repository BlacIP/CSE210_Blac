using System;

public class Program
{
    private static Journal journal = new Journal();

    static void Main(string[] args)
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("==== Welcome ====");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display your journal entries");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load an exiting jounal file");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                WriteNewEntry();
            }
            else if (choice == "2")
            {
                DisplayJournal();
            }
            else if (choice == "3")
            {
                SaveJournal();
            }
            else if (choice == "4")
            {
                LoadJournal();
            }
            else if (choice == "5")
            {
                isRunning = false;
                Console.WriteLine("Exiting the program...");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }

            Console.WriteLine();
        }
    }

    static void WriteNewEntry()
    {
        string date = DateTime.Now.ToString("yyyy-MM-dd");
        string prompt = journal.GetRandomPrompt();

        Console.WriteLine($"Date: {date}");
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Response: ");
        string response = Console.ReadLine();

        JournalEntry entry = new JournalEntry(date, prompt, response);
        journal.AddEntry(entry);
    }

    static void DisplayJournal()
    {
        Console.WriteLine("==== Display Journal ====");
        Console.Write("Enter the file name of the saved journal: ");
        string fileName = Console.ReadLine();

        journal.LoadFromFile(fileName);
        journal.DisplayEntries();
    }

    static void SaveJournal()
    {
        Console.WriteLine("==== Save Journal ====");
        Console.Write("Enter the file name to save the journal: ");
        string fileName = Console.ReadLine();

        journal.SaveToFile(fileName);
        Console.WriteLine("Journal saved successfully.");
    }

    static void LoadJournal()
    {
        Console.WriteLine("==== Load Journal ====");
        Console.Write("Enter the file name to load the journal: ");
        string fileName = Console.ReadLine();

        journal.LoadFromFile(fileName);
        Console.WriteLine("Journal loaded successfully.");
    }
}
