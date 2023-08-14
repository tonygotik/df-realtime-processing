using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using MediatR;
using MessageInboundHandler.Applications.Masters.Commands;

namespace MessageInboundHandler;

public class MasterMessageHandler
{
    private readonly IMediator _mediator;
    public MasterMessageHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    [FunctionName("MasterMessageInbound")]
    public async Task MasterMessageInbound(
        [ServiceBusTrigger("%MasterServiceBusTopic%", "subtopic", Connection = "ServiceBusConnectionString")]
        string message,
        ExecutionContext executionContext,
        ILogger logger)
    {
        try
        {
            Console.WriteLine(message);
            await _mediator.Publish(new MasterCommand
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
