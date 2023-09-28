using Application.Common.Interfaces.Persistence;

using Domain.Menu;

namespace Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private readonly List<Menu> _menus = new();

    public void Add(Menu menu)
    {
        _menus.Add(menu);
    }
}