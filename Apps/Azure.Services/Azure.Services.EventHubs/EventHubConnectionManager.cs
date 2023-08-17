using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs;
using Microsoft.Extensions.Options;
using Azure.Services.EventHubs.Settings;

namespace Azure.Services.EventHubs;

public class EventHubConnectionManager : IEventHubConnectionManager
{
    private readonly EventHubSettings _options;

    public EventHubConnectionManager(IOptions<EventHubSettings> options)
    {
        _options = options.Value;
    }

    public EventHubProducerClient CreateEventHubClient()
    {
        var producerOptions = new EventHubProducerClientOptions
        {
            RetryOptions = new EventHubsRetryOptions
            {
                MaximumRetries = _options.RetryNumber,
                TryTimeout = TimeSpan.FromSeconds(_options.RetryTimeoutSecond),
            },
            
        };

        return new EventHubProducerClient(_options.EndPoint, producerOptions);
    }

    public EventHubProducerClient CreateEventHubClient(string hubName)
    {
        var producerOptions = new EventHubProducerClientOptions
        {
            RetryOptions = new EventHubsRetryOptions
            {
                MaximumRetries = _options.RetryNumber,
                TryTimeout = TimeSpan.FromSeconds(_options.RetryTimeoutSecond),
            }
        };

        return new EventHubProducerClient(_options.EventHubConnection, hubName, producerOptions);
    }
}