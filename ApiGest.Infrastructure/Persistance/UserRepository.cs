namespace ApiGest.Infrastructure.Persistance
{
    using ApiGest.Application.Common.Interfaces.Persistance;
    using ApiGest.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(u => u.Email == email);
        }

        public void Add(User user)
        {
            _users.Add(user);
        }
    }
}