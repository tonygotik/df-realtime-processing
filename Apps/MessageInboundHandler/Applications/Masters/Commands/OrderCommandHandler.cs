using Azure.Services.EventHubs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MessageInboundHandler.Applications.Masters.Commands;

public class OrderCommandHandler : INotificationHandler<OrderCommand>
{
    private readonly IEventHubService _eventHubService;
    public OrderCommandHandler(IEventHubService eventHubService)
    {
        _eventHubService = eventHubService;
    }
    public async Task Handle(OrderCommand notification, CancellationToken cancellationToken)
    {
        await _eventHubService.SendOrderMessageAsync(notification.Message);
    }
}
