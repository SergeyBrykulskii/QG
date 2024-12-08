namespace QueueGen.Infrastructure.Entities;

public class Coefficient
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid DisciplineId { get; set; }
    public double Value { get; set; }
    public DateTime LastSubmissionDate { get; set; }
    
    
    public Discipline? Discipline { get; set; }
    public User? User { get; set; }
}