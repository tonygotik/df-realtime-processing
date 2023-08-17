using Azure.Services.EventHubs.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.Services.EventHubs.Extensions;

public static class EventHubExtensions
{
    public static IServiceCollection AddEventHubService(this IServiceCollection services)
    {
        services.AddEventHubSettings();
        services.AddSingleton<IEventHubConnectionManager, EventHubConnectionManager>();
        services.AddSingleton<IEventHubService, EventHubService>();

        return services;
    }
    private static void AddEventHubSettings(this IServiceCollection services)
    {
        var endpoint = GetEventHubEndpoint();
        var connection = GetEventHubConnection();
        var retryNumber = Environment.GetEnvironmentVariable("EventHubRetryNumber") ?? throw new ArgumentNullException(null, "EventHubRetryNumber");
        var retryTimeout = Environment.GetEnvironmentVariable("EventHubRetryTimeoutSecond") ?? throw new ArgumentNullException(null, "EventHubRetryTimeoutSecond");

        services.Configure<EventHubSettings>(settings =>
        {
            settings.EndPoint = endpoint;
            settings.RetryNumber = int.Parse(retryNumber);
            settings.RetryTimeoutSecond = int.Parse(retryTimeout);
            settings.EventHubConnection = connection;
        });
    }

    private static string GetEventHubEndpoint()
    {
        var endpoint = Environment.GetEnvironmentVariable("EventHubEndpoint");

        if (string.IsNullOrEmpty(endpoint))
        {
            endpoint = Environment.GetEnvironmentVariable("AlertEventHubEndpoint");
        }

        if (string.IsNullOrEmpty(endpoint))
        {
            throw new ArgumentNullException(null, "Missing the endpoint configuration for event hub!");
        }

        return endpoint;
    }

    private static string GetEventHubConnection()
    {
        var connection = Environment.GetEnvironmentVariable("EventHubConnection");

        if (string.IsNullOrEmpty(connection))
        {
            throw new ArgumentNullException(null, "Missing the connection configuration for event hub!");
        }

        return connection;
    }
}
