using System;
using System.IO;
using System.Threading;

public class EventUpdate : Event
{
    private const string CsvFilePath = "events.csv";

    public override void UpdateEvent()
    {
        Console.WriteLine("Enter the name or ID of the event: ");
        string eventNameOrId = Console.ReadLine();
        string eventId = FindEventIdByNameOrId(eventNameOrId);
        if (eventId == null)
        {
            Console.WriteLine("Event not found.");
            return;
        }

        Console.WriteLine("Do you want to update event information or send a notification?");
        Console.WriteLine("1. Update event information");
        Console.WriteLine("2. Send notification");
        Console.Write("Enter your choice (1-2): ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.WriteLine("Which information do you want to update?");
                Console.WriteLine("1. Name");
                Console.WriteLine("2. Date");
                Console.WriteLine("3. Time");
                Console.WriteLine("4. Location");
                Console.WriteLine("5. Description");
                Console.WriteLine("6. Additional Requirements");
                Console.Write("Enter your choice (1-6): ");
                int updateChoice = int.Parse(Console.ReadLine());

                switch (updateChoice)
                {
                    case 1:
                        Console.Write("Enter the updated name: ");
                        Name = Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Enter the updated date (YYYY-MM-DD): ");
                        Date = DateTime.Parse(Console.ReadLine());
                        break;
                    case 3:
                        Console.Write("Enter the updated time: ");
                        Time = Console.ReadLine();
                        break;
                    case 4:
                        Console.Write("Enter the updated location: ");
                        Location = Console.ReadLine();
                        break;
                    case 5:
                        Console.Write("Enter the updated description: ");
                        Description = Console.ReadLine();
                        break;
                    case 6:
                        Console.Write("Enter the updated additional requirements: ");
                        AdditionalRequirements = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. No information updated.");
                        return;
                }

                Console.WriteLine("Event information updated successfully!");

                UpdateEventInCSV();

                Console.WriteLine("Sending the update to all event registrants/participants...");
                AnimateLoading();
                Console.WriteLine("Notification sent successfully!");
                break;
            case 2:
                Console.Write("Enter the notification message: ");
                string message = Console.ReadLine();

                Console.WriteLine("Sending the notification to all event registrants/participants...");
                AnimateLoading();
                Console.WriteLine("Notification sent successfully!");
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }

    private string FindEventIdByNameOrId(string eventNameOrId)
    {
        if (!File.Exists(CsvFilePath))
        {
            Console.WriteLine("Events data file does not exist.");
            return null;
        }

        using (StreamReader reader = new StreamReader(CsvFilePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] eventDetails = line.Split(',');
                string eventId = eventDetails[0];
                string eventName = eventDetails[1];

                if (eventId == eventNameOrId || eventName == eventNameOrId)
                {
                    return eventId;
                }
            }
        }

        return null;
    }

    public override void UpdateEventInCSV()
    {
        base.UpdateEventInCSV();
    }

   public override void AnimateLoading()
    {
        base.AnimateLoading();
    }
}
