namespace ApiGest.Domain.Common.Models;

public class IEntity{
    public Guid Id {get; set;} = Guid.NewGuid();
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}
}