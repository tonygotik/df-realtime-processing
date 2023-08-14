namespace Azure.Services.EventHubs;

public interface IEventHubService
{
    Task SendMessageAsync(string message);

    Task SendMessagesAsync(IEnumerable<string> message);
}
