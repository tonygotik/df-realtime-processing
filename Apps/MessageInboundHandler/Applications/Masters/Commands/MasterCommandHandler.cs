using Azure.Services.EventHubs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MessageInboundHandler.Applications.Masters.Commands;

public class MasterCommandHandler : INotificationHandler<MasterCommand>
{
    private readonly IEventHubService _eventHubService;
    public MasterCommandHandler(IEventHubService eventHubService)
    {
        _eventHubService = eventHubService;
    }
    public async Task Handle(MasterCommand notification, CancellationToken cancellationToken)
    {
        await _eventHubService.SendMessageAsync(notification.Message);
    }
}
