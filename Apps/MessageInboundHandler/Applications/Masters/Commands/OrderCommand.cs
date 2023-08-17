using MediatR;

namespace MessageInboundHandler.Applications.Masters.Commands;

public class OrderCommand : INotification
{
    public string Message { get; set; }
}
