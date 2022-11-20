namespace ApiGest.Application.Common.Interfaces.Persistance;


using ApiGest.Domain.Entities;

public interface IUserRepository{
    User? GetUserByEmail(string email);
    void Add(User user);
}