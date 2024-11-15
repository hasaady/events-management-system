namespace Evently.Events.Domain.Models;

public class Event
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }

    public string Description { get; set; }
    
     public string Location { get; set; }
    
    public DateTime StartAtUtc { get; set; }
    
    public DateTime EndAtUtc { get; set; }
    
    public EventStatus Status { get; set; }
}
 
public enum EventStatus
{
    Draft = 0,
    Published = 1,
    Completed = 2,
    Cancelled = 3,
}