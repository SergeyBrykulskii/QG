namespace QueueGen.Infrastructure.Entities;

public class Queue
{
    public Guid Id { get; set; }
    public Guid DisciplineId { get; set; }
    public DateTime LastClassDate { get; set; }
    
    
    public Discipline Discipline { get; set; }
    public List<QueueUser> QueueUsers { get; set; }
}