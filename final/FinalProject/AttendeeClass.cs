using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Attendee : Event
{
    private const string EventCsvFilePath = "events.csv";
    
    public string AttendeeId { get; set; }
    public new string EventId { get; set; }
    public new string Name { get; set; }
    public string Gender { get; set; }
    public string Email { get; set; }
    public string Telephone { get; set; }
    public bool CheckedIn { get; set; }

    public void ManageAttendees()
    {
    
        DisplayEvents();
        Console.WriteLine("Please Enter Event ID");
        string eventId = Console.ReadLine();
        List<Attendee> attendees = Attendee.FetchAttendeesFromCsv(eventId);
        Attendee.DisplayAttendees(attendees);

        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Accept Registration");
        Console.WriteLine("2. Decline Registration");
        Console.WriteLine("3. Update Check-In Status");
        Console.Write("Enter your choice (1-3): ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.Write("Enter Attendee ID: ");
                string attendeeId = Console.ReadLine();
                Attendee.AcceptRegistration(attendees, attendeeId);
                break;
            case 2:
                Console.Write("Enter Attendee ID: ");
                attendeeId = Console.ReadLine();
                Attendee.DeclineRegistration(attendees, attendeeId);
                break;
            case 3:
                Console.Write("Enter Attendee ID: ");
                attendeeId = Console.ReadLine();
                Console.Write("Check-In Status (True/False): ");
                bool isCheckedIn = bool.Parse(Console.ReadLine());
                Attendee.UpdateCheckInStatus(attendees, attendeeId, isCheckedIn);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }
    
    public static List<Attendee> FetchAttendeesFromCsv(string eventId)
    {
        List<Attendee> attendees = new List<Attendee>();

        string csvFilePath = "attendees.csv";

        if (File.Exists(csvFilePath))
        {
            string[] lines = File.ReadAllLines(csvFilePath);
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');
                if (fields.Length >= 6 && fields[1] == eventId)
                {
                    Attendee attendee = new Attendee
                    {
                        AttendeeId = fields[0],
                        EventId = fields[1],
                        Name = fields[2],
                        Gender = fields[3],
                        Email = fields[4],
                        Telephone = fields[5],
                        CheckedIn = fields.Length >= 7 && bool.TryParse(fields[6], out bool isCheckedIn) ? isCheckedIn : false
                    };
                    attendees.Add(attendee);
                }
            }
        }

        return attendees;
    }

    public static void DisplayAttendees(List<Attendee> attendees)
    {
        Console.WriteLine("Attendee List:");
        foreach (Attendee attendee in attendees)
        {
            Console.WriteLine($"Attendee ID: {attendee.AttendeeId}");
            Console.WriteLine($"Name: {attendee.Name}");
            Console.WriteLine($"Gender: {attendee.Gender}");
            Console.WriteLine($"Email: {attendee.Email}");
            Console.WriteLine($"Telephone: {attendee.Telephone}");
            Console.WriteLine($"Checked-in: {(attendee.CheckedIn ? "Yes" : "No")}");
            Console.WriteLine();
        }
    }

    public static void AcceptRegistration(List<Attendee> attendees, string attendeeId)
    {
        Attendee attendee = attendees.FirstOrDefault(a => a.AttendeeId == attendeeId);
        if (attendee != null)
        {
            // Update the attendee's registration status
            // For example, set a "IsRegistered" flag to true in the CSV file
            Console.WriteLine($"Registration for attendee ID: {attendee.AttendeeId} has been accepted.");
        }
        else
        {
            Console.WriteLine("Invalid attendee ID.");
        }
    }

    public static void DeclineRegistration(List<Attendee> attendees, string attendeeId)
    {
        Attendee attendee = attendees.FirstOrDefault(a => a.AttendeeId == attendeeId);
        if (attendee != null)
        {
            // Remove the attendee from the list or mark them as declined in the CSV file
            Console.WriteLine($"Registration for attendee ID: {attendee.AttendeeId} has been declined.");
        }
        else
        {
            Console.WriteLine("Invalid attendee ID.");
        }
    }

    public static void UpdateCheckInStatus(List<Attendee> attendees, string attendeeId, bool isCheckedIn)
    {
        Attendee attendee = attendees.FirstOrDefault(a => a.AttendeeId == attendeeId);
        if (attendee != null)
        {
            attendee.CheckedIn = isCheckedIn;
            Console.WriteLine($"Check-in status for attendee ID: {attendee.AttendeeId} has been updated.");
        }
        else
        {
            Console.WriteLine("Invalid attendee ID.");
        }
    }

    public override void DisplayEvents()
    {
        base.DisplayEvents();
    }
}
