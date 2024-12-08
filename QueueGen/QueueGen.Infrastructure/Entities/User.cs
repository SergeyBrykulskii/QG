namespace QueueGen.Infrastructure.Entities;

public class User
{
    public Guid Id { get; set; }
    public required string Nickname { get; set; }
    public Guid GroupId { get; set; }
    
    
    public Group? Group { get; set; }
    public List<QueueUser> QueueUsers { get; set; }
    public List<Coefficient>? Coefficients { get; set; }
}