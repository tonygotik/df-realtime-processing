using MediatR;

namespace MessageInboundHandler.Applications.Masters.Commands;

public class MasterCommand : INotification
{
    public string Message { get; set; }
}
