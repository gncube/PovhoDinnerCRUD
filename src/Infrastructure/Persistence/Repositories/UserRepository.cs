using Application.Common.Interfaces.Persistence;
using Domain.Users;

namespace Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    public UserRepository()
    {

    }
    private static readonly List<User> _users = new();
    public User? GetUserByEmail(string email)
    {
        return _users.FirstOrDefault(u => u.Email == email);
    }

    public void Add(User user)
    {
        _users.Add(user);
    }
}