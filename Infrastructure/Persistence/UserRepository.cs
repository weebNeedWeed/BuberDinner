using Application.Common.Interfaces.Persistence;
using Domain.User;

namespace Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users = new();

    public User? FindByEmail(string email)
    {
        return _users.FirstOrDefault(x => x.Email.Equals(email));
    }

    public void Add(User user)
    {
        _users.Add(user);
    }
}