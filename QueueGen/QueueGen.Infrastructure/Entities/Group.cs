namespace QueueGen.Infrastructure.Entities;

public class Group
{
    public Guid Id { get; set; }
    public Guid AdminId { get; set; }
    public required string Name { get; set; }
    
    public User Admin { get; set; }
    public List<User> Users { get; set; }
    public List<Discipline>? Disciplines { get; set; }
}