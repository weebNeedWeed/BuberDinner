namespace Domain.Entities;

public class User
{
    public Guid Id { get; init; }
    public string FirstName { get; init; } = string.Empty; 
    public string LastName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}