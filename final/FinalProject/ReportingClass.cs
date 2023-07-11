using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Reporting
{
    private const string EventsCsvFilePath = "events.csv";
    private const string AttendeesCsvFilePath = "attendee.csv";

    public void GenerateEventAttendanceReport()
    {
        List<Event> events = ReadEventsFromCsv();
        if (events.Count == 0)
        {
            Console.WriteLine("No events found.");
            return;
        }

        Console.WriteLine("Available Events:");
        foreach (Event evnt in events)
        {
            Console.WriteLine($"{evnt.EventId}: {evnt.Name}");
        }

        Console.Write("Enter the Event ID or Name: ");
        string eventIdentifier = Console.ReadLine();

        Event selectedEvent = events.FirstOrDefault(evnt => evnt.EventId == eventIdentifier || evnt.Name == eventIdentifier);
        if (selectedEvent == null)
        {
            Console.WriteLine("Event not found.");
            return;
        }

        List<Attendee> attendees = ReadAttendeesFromCsv(selectedEvent.EventId);

        Console.WriteLine("Generating Event Attendance Report...");

        int totalAttendees = attendees.Count;

        Console.WriteLine($"Total Attendees: {totalAttendees}");

        Console.WriteLine("Event Attendance Report generated!");

        // Prompt user to save the report to a new CSV file
        Console.Write("Enter a name for the new report file: ");
        string reportFileName = Console.ReadLine();
        string reportFilePath = $"{reportFileName}.csv";
        SaveReportToCsv(reportFilePath, attendees);
    }

    public void GenerateTicketSalesReport()
    {
        List<Event> events = ReadEventsFromCsv();
        if (events.Count == 0)
        {
            Console.WriteLine("No events found.");
            return;
        }

        Console.WriteLine("Available Events:");
        foreach (Event evnt in events)
        {
            Console.WriteLine($"{evnt.EventId}: {evnt.Name}");
        }

        Console.Write("Enter the Event ID or Name: ");
        string eventIdentifier = Console.ReadLine();

        Event selectedEvent = events.FirstOrDefault(evnt => evnt.EventId == eventIdentifier || evnt.Name == eventIdentifier);
        if (selectedEvent == null)
        {
            Console.WriteLine("Event not found.");
            return;
        }

        Console.WriteLine("Generating Ticket Sales Report...");

        // Fetch the ticket sales data from the event and attendee CSV files
        int totalTicketsSold = GetTotalTicketsSold(selectedEvent.EventId);

        Console.WriteLine($"Total Tickets Sold: {totalTicketsSold}");

        Console.WriteLine("Ticket Sales Report generated!");

        // Prompt user to save the report to a new CSV file
        Console.Write("Enter a name for the new report file: ");
        string reportFileName = Console.ReadLine();
        string reportFilePath = $"{reportFileName}.csv";
        SaveReportToCsv(reportFilePath, null);
    }

    public void GenerateDemographicsReport()
    {
        List<Event> events = ReadEventsFromCsv();
        if (events.Count == 0)
        {
            Console.WriteLine("No events found.");
            return;
        }

        Console.WriteLine("Available Events:");
        foreach (Event evnt in events)
        {
            Console.WriteLine($"{evnt.EventId}: {evnt.Name}");
        }

        Console.Write("Enter the Event ID or Name: ");
        string eventIdentifier = Console.ReadLine();

        Event selectedEvent = events.FirstOrDefault(evnt => evnt.EventId == eventIdentifier || evnt.Name == eventIdentifier);
        if (selectedEvent == null)
        {
            Console.WriteLine("Event not found.");
            return;
        }

        List<Attendee> attendees = ReadAttendeesFromCsv(selectedEvent.EventId);

        Console.WriteLine("Generating Demographics Report...");

        int totalMale = attendees.Count(a => a.Gender == "Male");
        int totalFemale = attendees.Count(a => a.Gender == "Female");
       
        Console.WriteLine($"Total Male: {totalMale}");
        Console.WriteLine($"Total Female: {totalFemale}");

        Console.WriteLine("Demographics Report generated!");

        // Prompt user to save the report to a new CSV file
        Console.Write("Enter a name for the new report file: ");
        string reportFileName = Console.ReadLine();
        string reportFilePath = $"{reportFileName}.csv";
        SaveReportToCsv(reportFilePath, attendees);
    }

    private List<Event> ReadEventsFromCsv()
    {
        List<Event> events = new List<Event>();

        if (!File.Exists(EventsCsvFilePath))
        {
            return events;
        }

        string[] lines = File.ReadAllLines(EventsCsvFilePath);
        foreach (string line in lines.Skip(1))
        {
            string[] eventDetails = line.Split(',');
            Event evnt = new Event
            {
                EventId = eventDetails[0],
                Name = eventDetails[1],
                Date = DateTime.Parse(eventDetails[2]),
                Time = eventDetails[3],
                Location = eventDetails[4],
                Description = eventDetails[5],
                AdditionalRequirements = eventDetails[6]
            };
            events.Add(evnt);
        }

        return events;
    }

    private List<Attendee> ReadAttendeesFromCsv(string eventId)
    {
        List<Attendee> attendees = new List<Attendee>();

        if (!File.Exists(AttendeesCsvFilePath))
        {
            return attendees;
        }

        string[] lines = File.ReadAllLines(AttendeesCsvFilePath);
        foreach (string line in lines.Skip(1))
        {
            string[] attendeeDetails = line.Split(',');
            if (attendeeDetails.Length == 6 && attendeeDetails[1] == eventId)
            {
                Attendee attendee = new Attendee
                {
                    AttendeeId = attendeeDetails[0],
                    EventId = attendeeDetails[1],
                    Name = attendeeDetails[2],
                    Gender = attendeeDetails[3],
                    Email = attendeeDetails[4],
                    Telephone = attendeeDetails[5],
                    CheckedIn = bool.Parse(attendeeDetails[6])
                };
                attendees.Add(attendee);
            }
        }

        return attendees;
    }

    private int GetTotalTicketsSold(string eventId)
    {
        int totalTicketsSold = 0;

        if (!File.Exists(AttendeesCsvFilePath))
        {
            return totalTicketsSold;
        }

        string[] lines = File.ReadAllLines(AttendeesCsvFilePath);
        foreach (string line in lines.Skip(1))
        {
            string[] attendeeDetails = line.Split(',');
            if (attendeeDetails.Length == 6 && attendeeDetails[1] == eventId)
            {
                totalTicketsSold++;
            }
        }

        return totalTicketsSold;
    }

    private void SaveReportToCsv(string filePath, List<Attendee> attendees)
    {
        // Save the report to a new CSV file
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            // Write the report content to the CSV file
            if (attendees != null)
            {
                foreach (Attendee attendee in attendees)
                {
                    string line = $"{attendee.AttendeeId},{attendee.EventId},{attendee.Name},{attendee.Gender},{attendee.Email},{attendee.Telephone},{attendee.CheckedIn}";
                    writer.WriteLine(line);
                }
            }

            Console.WriteLine("Report saved to a new CSV file.");
        }
    }
}
