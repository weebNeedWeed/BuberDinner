using Application.Common.Interfaces.Persistence;

using Domain.Host.ValueObjects;
using Domain.Menu;
using Domain.Menu.Entities;

using ErrorOr;

using MediatR;

namespace Application.Menus.Commands;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var menu = Menu.Create(
            HostId.Create(command.HostId),
            command.Name,
            command.Description,
            command.Sections.Select(s => MenuSection.Create(
                s.Name,
                s.Description,
                s.Items.Select(i => MenuItem.Create(
                    i.Name,
                    i.Description)).ToList())).ToList()
        );

        _menuRepository.Add(menu);

        return menu;
    }
}
