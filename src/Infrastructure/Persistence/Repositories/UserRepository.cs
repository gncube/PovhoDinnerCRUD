using Application.Common.Interfaces.Persistence;
using Domain.Users;

namespace Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly PovhoDinnerDbContext _dbContext;

    public UserRepository(PovhoDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public User? GetUserByEmail(string email)
    {
        return _dbContext.Users.FirstOrDefault(u => u.Email == email);
    }

    public void Add(User user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }
}