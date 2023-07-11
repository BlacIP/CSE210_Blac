using System;

public class Program
{
    public static void Main(string[] args)
    {
        EventCreator creator = new EventCreator();
        EventAttendee attendee = new EventAttendee();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("----- Event Management System -----");
            Console.WriteLine("1. Create Event");
            Console.WriteLine("2. Update Event");
            Console.WriteLine("3. Manage Attendee");
            Console.WriteLine("4. Generate Reports");
            Console.WriteLine("5. Register for Event");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice (1-6): ");

            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    creator.CreateEvent();
                    break;
                case 2:
                    creator.UpdateEvent();
                    break;
                case 3:
                    
                    creator.ManageAttendee();
                    break;
                case 4:
                    GenerateReportsMenu(creator);
                    break;
                case 5:
                    attendee.RegisterForEvent();
                    break;
                case 6:
                    exit = true;
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private static void GenerateReportsMenu(EventCreator creator)
    {
        bool back = false;
        while (!back)
        {
            Console.WriteLine("----- Generate Reports -----");
            Console.WriteLine("1. Event Attendance Report");
            Console.WriteLine("2. Ticket Sales Report");
            Console.WriteLine("3. Demographics Report");
            Console.WriteLine("4. Back to Main Menu");
            Console.Write("Enter your choice (1-4): ");

            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    creator.GenerateEventAttendanceReport();
                    break;
                case 2:
                    creator.GenerateTicketSalesReport();
                    break;
                case 3:
                    creator.GenerateDemographicsReport();
                    break;
                case 4:
                    back = true;
                    Console.WriteLine("Returning to Main Menu...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
    
}
