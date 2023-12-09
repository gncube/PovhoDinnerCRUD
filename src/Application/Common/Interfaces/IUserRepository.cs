using Domain.Users;

namespace Application.Common.Interfaces;
public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}
