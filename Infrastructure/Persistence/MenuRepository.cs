using Application.Common.Interfaces.Persistence;

using Domain.Menu;

namespace Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private BuberDinnerDbContext _dbContext;

    public MenuRepository(BuberDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Menu menu)
    {
        _dbContext.Add(menu);
        _dbContext.SaveChanges();
    }
}