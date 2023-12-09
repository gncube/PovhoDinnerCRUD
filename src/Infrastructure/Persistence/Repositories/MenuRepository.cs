using Application.Common.Interfaces.Persistence;
using Domain.Menus;

namespace Infrastructure.Persistence.Repositories;
public class MenuRepository : IMenuRepository
{
    private readonly PovhoDinnerDbContext _dbContext;

    public MenuRepository(PovhoDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Add(Menu menu)
    {
        _dbContext.Menus.Add(menu);
        _dbContext.SaveChanges();
    }
}
