namespace ApiGest.Domain.Common.Models;

using ApiGest.Domain.Entities;

public class IEntity{
    public Guid Id {get; set;} = Guid.NewGuid();
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}
    public User? CreatedBy {get; set;}
    public User? UpdatedBy {get; set;}
}