namespace ApiGest.Domain.Entities;
public class User
{
    public Guid Id {get; set;} = Guid.NewGuid();
    public string Firstname {get; set;} = null!;
    public string Lastname {get; set;} = null!;
    public string Email {get; set;} = null!;
    public string Password {get; set;} = null!;
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}
}