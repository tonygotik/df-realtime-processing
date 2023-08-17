using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using Azure.Services.EventHubs.Settings;
using System.Text;

namespace Azure.Services.EventHubs;

public class EventHubService : IEventHubService
{
    private readonly IEventHubConnectionManager _eventHubConnectionManager;

    public EventHubService(IEventHubConnectionManager eventHubConnectionManager)
    {
        _eventHubConnectionManager = eventHubConnectionManager;
    }

    public async Task SendMessageAsync(string message)
    {
        await using var producerClient = _eventHubConnectionManager.CreateEventHubClient();
        
        using var eventBatch = await producerClient.CreateBatchAsync();
        eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes(message)));

        await producerClient.SendAsync(eventBatch);
    }

    public async Task SendMessagesAsync(IEnumerable<string> messages)
    {
        await using var producerClient = _eventHubConnectionManager.CreateEventHubClient();
        using var eventBatch = await producerClient.CreateBatchAsync();

        foreach (var message in messages)
        {
            eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes(message)));
        }

        await producerClient.SendAsync(eventBatch);
    }

    public async Task SendOrderMessageAsync(string message)
    {
        await using var producerClient = _eventHubConnectionManager.CreateEventHubClient(EventHubConstants.OrderHub);

        using var eventBatch = await producerClient.CreateBatchAsync();
        eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes(message)));

        await producerClient.SendAsync(eventBatch);
    }
}
