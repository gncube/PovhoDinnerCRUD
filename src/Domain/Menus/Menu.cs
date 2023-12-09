using Domain.Common.ValueObjects;
using Domain.Dinners;
using Domain.Hosts.ValueObjects;
using Domain.MenuReview.ValueObjects;
using Domain.Menus.Entities;
using Domain.Menus.ValueObjects;

namespace Domain.Menus;
public sealed class Menu
{
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();

    public string Name { get; private set; }
    public string Description { get; private set; }
    public AverageRating AverageRating { get; }

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

    public HostId HostId { get; private set; }
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    public DateTimeOffset CreatedDateTime { get; private set; }
    public DateTimeOffset LastUpdatedDateTime { get; set; }

    private Menu(
        MenuId menuId,
        HostId hostId,
        string name,
        string description,
        AverageRating averageRating,
        List<MenuSection> sections)
    //: base(menuId) 
    // TODO: Add base class
    {
        HostId = hostId;
        Name = name;
        Description = description;
        _sections = sections;
        AverageRating = averageRating;
    }

    public static Menu Create(
       HostId hostId,
       string name,
       string description,
       List<MenuSection>? sections = null)
    {
        var menu = new Menu(
            MenuId.CreateUnique(),
            hostId,
            name,
            description,
            AverageRating.CreateNew(0),
            sections ?? new());

        // TODO: Add domain event
        //menu.AddDomainEvent(new MenuCreated(menu));

        return menu;
    }
}
