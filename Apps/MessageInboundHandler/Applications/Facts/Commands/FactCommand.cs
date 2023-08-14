using MediatR;

namespace MessageInboundHandler.Applications.Facts.Commands;

public class FactCommand : INotification
{
    public string Message { get; set; }
}
