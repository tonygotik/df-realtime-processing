using Azure.Services.DataLake.Storage.Settings;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Services.DataLake.Storage.Extensions;

public static class DataLakeStorageExtensions
{
    public static IServiceCollection AddServiceBus(this IServiceCollection services)
    {
        services.AddServiceBusSettings();
        services.AddSingleton<IDataLakeStorageManager, DataLakeStorageManager>();

        return services;
    }

    private static void AddServiceBusSettings(this IServiceCollection services)
    {
        var connectionString = Environment.GetEnvironmentVariable("ServiceBusConnectionString") ?? 
                                throw new ArgumentNullException(null, "ServiceBusConnectionString");
        var topic = Environment.GetEnvironmentVariable("ServiceBusTopic") ?? 
                                throw new ArgumentNullException(null, "ServiceBusTopic");

        ArgumentNullException.ThrowIfNull(connectionString, "ServiceBusConnectionString is not found.");

        services.Configure<DataLakeStorageSetting>(settings =>
        {
            settings.SharedKeyCredential = connectionString;
            settings.Topic = topic;
        });
    }
}
