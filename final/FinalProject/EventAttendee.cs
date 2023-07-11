public class EventAttendee
{
    private EventRegistration eventRegistration;

    public EventAttendee()
    {
        eventRegistration = new EventRegistration();
    }

    public void RegisterForEvent()
    {
        eventRegistration.RegisterForEvent();
    }
}
