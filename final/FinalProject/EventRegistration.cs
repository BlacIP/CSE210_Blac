using System;
using System.IO;

public class EventRegistration : Event
{
    private const string EventCsvFilePath = "events.csv";
    private const string AttendeeCsvFilePath = "attendees.csv";

    public void RegisterForEvent()
    {
        Console.WriteLine("Available Events:");
        DisplayEvents();

        Console.WriteLine("Enter the Event ID you want to register for:");
        string eventId = Console.ReadLine();

        Event selectedEvent = FindEventById(eventId);
        if (selectedEvent == null)
        {
            Console.WriteLine("Event not found.");
            return;
        }

        Console.WriteLine("Enter attendee details:");
        string attendeeId = GenerateUniqueId();
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Gender: ");
        string gender = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();
        Console.Write("Telephone: ");
        string telephone = Console.ReadLine();

        Attendee attendee = new Attendee
        {
            AttendeeId = attendeeId,
            EventId = eventId,
            Name = name,
            Gender = gender,
            Email = email,
            Telephone = telephone
        };

        AnimateLoading();
        SaveAttendeetToCSV(attendee);
        Console.WriteLine("Registration successful!");

        PurchaseTicket(selectedEvent);
    }

    public override void DisplayEvents()
    {
        base.DisplayEvents();
    }

    private Event FindEventById(string eventId)
    {
        if (File.Exists(EventCsvFilePath))
        {
            string[] eventLines = File.ReadAllLines(EventCsvFilePath);
            foreach (string line in eventLines)
            {
                string[] eventDetails = line.Split(',');
                string existingEventId = eventDetails[0];
                if (existingEventId == eventId)
                {
                    return new Event
                    {
                        EventId = existingEventId,
                        Name = eventDetails[1],
                        Date = DateTime.Parse(eventDetails[2]),
                        Time = eventDetails[3],
                        Location = eventDetails[4],
                        Description = eventDetails[5],
                        AdditionalRequirements = eventDetails[6]
                    };
                }
            }
        }

        return null;
    }


    public void SaveAttendeetToCSV(Attendee attendee)
    {
        string csvData = $"{attendee.AttendeeId},{attendee.EventId},{attendee.Name},{attendee.Gender},{attendee.Email},{attendee.Telephone}";
        SaveToCsvCore(csvData, "attendees.csv");
    }

    private void PurchaseTicket(Event selectedEvent)
    {
        Console.WriteLine("Do you want to purchase a ticket? (Y/N)");
        string choice = Console.ReadLine().ToLower();
        if (choice == "y")
        {
            AnimateLoading();
            Console.WriteLine("Ticket purchased successfully!");
        }
    }

    public override string GenerateUniqueId()
    {
        Random random = new Random();
        int randomNumber = random.Next(100, 1000);

        return "AT" + randomNumber.ToString();
    }
    public override void AnimateLoading()
    {
        base.AnimateLoading();
    }
}
