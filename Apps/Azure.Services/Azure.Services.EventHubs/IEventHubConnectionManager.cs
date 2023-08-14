using Azure.Messaging.EventHubs.Producer;

namespace Azure.Services.EventHubs;

public interface IEventHubConnectionManager
{
    EventHubProducerClient CreateEventHubClient();
}
