using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using MediatR;
using MessageInboundHandler.Applications.Facts.Commands;

namespace MessageInboundHandler;

public class FactMessageHandler
{
    private readonly IMediator _mediator;
    public FactMessageHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    [FunctionName("FactMessageInbound")]
    public async Task FactMessageInbound(
        [ServiceBusTrigger("%FactServiceBusTopic%", "subtopic", Connection = "ServiceBusConnectionString")]
        string message,
        ExecutionContext executionContext,
        ILogger logger)
    {
        try
        {
            await _mediator.Publish(new FactCommand
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
