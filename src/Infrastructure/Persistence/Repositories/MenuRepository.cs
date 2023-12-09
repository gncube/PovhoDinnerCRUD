using Application.Common.Interfaces.Persistence;
using Domain.Menus;

namespace Infrastructure.Persistence.Repositories;
public class MenuRepository : IMenuRepository
{
    private static readonly List<Menu> __menuList = new();
    public void Add(Menu menu)
    {
        __menuList.Add(menu);
    }
}
