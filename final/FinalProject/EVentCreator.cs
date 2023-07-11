public class EventCreator
{
    private Event eventManager;
    private EventUpdate eventUpdater;
    private Attendee attendeeManager;
    private Reporting reporting;

    public EventCreator()
    {
        eventManager = new Event();
        eventUpdater = new EventUpdate();
        attendeeManager = new Attendee();
        reporting = new Reporting();
    }

    public void CreateEvent()
    {
        eventManager.CreateEvent();
    }

    public void UpdateEvent()
    {
        eventUpdater.UpdateEvent();
    }

    public void ManageAttendee()
    {
        attendeeManager.ManageAttendees();
    }


    public void GenerateEventAttendanceReport()
    {
        reporting.GenerateEventAttendanceReport();
    }

    public void GenerateTicketSalesReport()
    {
        reporting.GenerateTicketSalesReport();
    }

    public void GenerateDemographicsReport()
    {
        reporting.GenerateDemographicsReport();
    }
}