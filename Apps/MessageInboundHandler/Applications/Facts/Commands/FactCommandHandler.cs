using Azure.Services.EventHubs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MessageInboundHandler.Applications.Facts.Commands;

public class FactCommandHandler : INotificationHandler<FactCommand>
{
    private readonly IEventHubService _eventHubService;
    public FactCommandHandler(IEventHubService eventHubService)
    {
        _eventHubService = eventHubService;
    }

    public async Task Handle(FactCommand notification, CancellationToken cancellationToken)
    {
        await _eventHubService.SendMessageAsync(notification.Message);
    }
}
