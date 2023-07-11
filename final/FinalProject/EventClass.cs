using System;
using System.IO;

public class Event
{
    private const string EventCsvFilePath = "events.csv";
    public string EventId { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string Time { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public string AdditionalRequirements { get; set; }

    public virtual void CreateEvent()
    {
        Console.WriteLine("Enter event details:");
        EventId = GenerateUniqueId();
        Console.Write("Name: ");
        Name = Console.ReadLine();
        Console.Write("Date (YYYY-MM-DD): ");
        Date = DateTime.Parse(Console.ReadLine());
        Console.Write("Time: ");
        Time = Console.ReadLine();
        Console.Write("Location: ");
        Location = Console.ReadLine();
        Console.Write("Description: ");
        Description = Console.ReadLine();
        Console.Write("Additional Requirements: ");
        AdditionalRequirements = Console.ReadLine();

        SaveEventToCSV(); // Save the event details to CSV

        Console.WriteLine("Event created successfully!");
        Console.WriteLine("Name of Event: " + Name);
        Console.WriteLine("Event ID: " + EventId);

    }

    public virtual void UpdateEvent()
    {
        Console.WriteLine("Enter updated event details:");
        Console.Write("Name: ");
        Name = Console.ReadLine();
        Console.Write("Date (YYYY-MM-DD): ");
        Date = DateTime.Parse(Console.ReadLine());
        Console.Write("Time: ");
        Time = Console.ReadLine();
        Console.Write("Location: ");
        Location = Console.ReadLine();
        Console.Write("Description: ");
        Description = Console.ReadLine();
        Console.Write("Additional Requirements: ");
        AdditionalRequirements = Console.ReadLine();
       

        UpdateEventInCSV(); // Update the event details in the CSV

        Console.WriteLine("Event Updated successfully!");
        Console.WriteLine("Name of Event: " + Name);
        Console.WriteLine("Event ID: " + EventId);
    }

    public virtual string GenerateUniqueId()
    {
        Random random = new Random();

        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        char randomLetter = letters[random.Next(letters.Length)];

        int randomNumber = random.Next(100, 1000);

        return randomNumber.ToString() + randomLetter.ToString();
    }

    public virtual void SaveEventToCSV()
    {
        if (this is Event)
        {
            string csvData = $"{EventId},{Name},{Date},{Time},{Location},{Description},{AdditionalRequirements}";
            SaveToCsvCore(csvData, "events.csv", "EventId, Name, Date, Time, Location, Description, Additional Requirements");
        }
        else if (this is Attendee)
        {
            Attendee attendee = this as Attendee;
            string csvData = $"{attendee.AttendeeId},{attendee.EventId},{attendee.Name},{attendee.Gender},{attendee.Email},{attendee.Telephone}";
            SaveToCsvCore(csvData, "attendees.csv");
        }
    }

    public virtual void SaveToCsvCore(string csvData, string csvFilePath, string csvHeader = null)
    {
        // Check if the CSV file exists
        bool fileExists = File.Exists(csvFilePath);

        // Write the data to the CSV file
        using (StreamWriter writer = new StreamWriter(csvFilePath, true))
        {
            // If the file doesn't exist or a custom header is specified, write the CSV header
            if (!fileExists || !string.IsNullOrEmpty(csvHeader))
            {
                writer.WriteLine(csvHeader);
            }

            writer.WriteLine(csvData);
        }

        Console.WriteLine("Data saved to CSV file.");
    }


    public virtual void UpdateEventInCSV()
    {
        string csvFilePath = "events.csv";
        List<string> lines = new List<string>();

        // Read all events from the CSV file
        if (File.Exists(csvFilePath))
        {
        lines.AddRange(File.ReadAllLines(csvFilePath));
        }

          // Find and update the specific event details
        for (int i = 1; i < lines.Count; i++) // Start from index 1 to skip the header
        {
            string[] fields = lines[i].Split(',');
            if (fields.Length >= 7 && fields[0] == EventId)
            {
                fields[1] = Name;
                fields[2] = Date.ToString("yyyy-MM-dd");
                fields[3] = Time;
                fields[4] = Location;
                fields[5] = Description;
                fields[6] = AdditionalRequirements;
                lines[i] = string.Join(",", fields);
                break; // Assuming EventId is unique, so we can exit the loop after finding the event
            }
        }

        // Write the updated event details back to the CSV file
        File.WriteAllLines(csvFilePath, lines);

        Console.WriteLine("Event details saved.");
        }
    
    public virtual void AnimateLoading()
    {
        Console.Write("Loading");
        for (int i = 0; i < 3; i++)
        {
            Thread.Sleep(500);
            Console.Write(".");
        }
        Console.WriteLine();
    }

    public virtual void DisplayEvents()
    {
        if (File.Exists(EventCsvFilePath))
        {
            string[] eventLines = File.ReadAllLines(EventCsvFilePath);
            foreach (string line in eventLines)
            {
                string[] eventDetails = line.Split(',');
                string eventId = eventDetails[0];
                string eventName = eventDetails[1];
                Console.WriteLine($"{eventId} - {eventName}");
            }
        }
    }
       
}
