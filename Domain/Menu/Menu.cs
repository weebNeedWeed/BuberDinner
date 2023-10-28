using Domain.Common.Models;
using Domain.Common.ValueObjects;
using Domain.Dinner.ValueObjects;
using Domain.Host.ValueObjects;
using Domain.Menu.Entities;
using Domain.Menu.ValueObjects;
using Domain.MenuReview.ValueObjects;

namespace Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();

    public string Name { get; private set; }
    public string Description { get; private set; }
    public AverageRating AverageRating { get; private set; }
    public HostId HostId { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    private Menu(MenuId menuId,
        string name,
        string description,
        HostId hostId,
        DateTime createdDateTime,
        DateTime updatedDateTime,
        AverageRating averageRating,
        List<MenuSection> sections) : base(menuId)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
        AverageRating = averageRating;

        _sections.AddRange(sections);
    }

    public static Menu Create(
        HostId hostId,
        string name,
        string description,
        List<MenuSection> sections)
    {
        return new Menu(
            MenuId.CreateUnique(),
            name,
            description,
            hostId,
            DateTime.UtcNow,
            DateTime.UtcNow,
            AverageRating.Create(0, 0),
            sections ?? new());
    }

    private Menu()
    {

    }
}