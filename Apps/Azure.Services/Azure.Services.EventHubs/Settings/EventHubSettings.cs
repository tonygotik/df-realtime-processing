namespace Azure.Services.EventHubs.Settings;

public class EventHubSettings
{
    public string EndPoint { get; set; } = string.Empty;

    public int RetryNumber { get; set; }

    public int RetryTimeoutSecond { get; set; }

    public string EventHubConnection { get; set; } = string.Empty;
}
