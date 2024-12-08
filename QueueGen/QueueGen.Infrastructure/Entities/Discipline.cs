namespace QueueGen.Infrastructure.Entities;

public class Discipline
{
    public Guid Id { get; set; }
    public Guid GroupId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    
    
    public Group Group { get; set; }
    public List<Coefficient>? Coefficients { get; set; }
    public List<Queue>? Queues { get; set; }
}