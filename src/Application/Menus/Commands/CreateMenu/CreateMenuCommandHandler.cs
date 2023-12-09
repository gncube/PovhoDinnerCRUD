using Application.Common.Interfaces.Persistence;
using Domain.Hosts.ValueObjects;
using Domain.Menus;
using Domain.Menus.Entities;
using ErrorOr;
using MediatR;

namespace Application.Menus.Commands.CreateMenu;
public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }
    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Create Menu
        var menu = Menu.Create(
            hostId: HostId.Create(request.HostId),
            name: request.Name,
            description: request.Description,
            sections: request.Sections.ConvertAll(sections => MenuSection.Create(
                name: sections.Name,
                description: sections.Description,
                items: sections.Items.ConvertAll(items => MenuItem.Create(
                    name: items.Name,
                    description: items.Description)))));

        // Persist Menu
        _menuRepository.Add(menu);

        return menu;
    }
}
