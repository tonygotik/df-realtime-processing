using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using MediatR;
using MessageInboundHandler.Applications.Masters.Commands;

namespace MessageInboundHandler;

public class OrderMessageHandler
{
    private readonly IMediator _mediator;
    public OrderMessageHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    [FunctionName("OrderInbound")]
    public async Task OrderInbound(
        [ServiceBusTrigger("%MasterServiceBusTopic%", "orders", Connection = "ServiceBusConnectionString")]
        string message,
        ExecutionContext executionContext,
        ILogger logger)
    {
        try
        {
            Console.WriteLine(message);
            await _mediator.Publish(new OrderCommand
            {
                Message = message
            });
        }
        catch (Exception ex)
        {
            logger.LogError($"Error {executionContext.FunctionName}: [{ex.Message} {ex.StackTrace}]");
        }
    }
}
