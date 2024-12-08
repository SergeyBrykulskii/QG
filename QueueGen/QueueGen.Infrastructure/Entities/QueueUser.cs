namespace QueueGen.Infrastructure.Entities;

public class QueueUser
{
    public Guid Id { get; set; }
    public Guid QueueId { get; set; }
    public Guid UserId { get; set; }
    public int Position { get; set; }
    
    public Queue Queue { get; set; }
    public User User { get; set; }
}