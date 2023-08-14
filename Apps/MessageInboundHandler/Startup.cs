using Azure.Services.EventHubs.Extensions;
using MessageInboundHandler;
using MessageInboundHandler.Applications.Facts.Commands;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

[assembly: FunctionsStartup(typeof(Startup))]
namespace MessageInboundHandler;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddLogging();
        builder.Services.AddMediatR(p => p.RegisterServicesFromAssembly(typeof(Startup).Assembly));
        builder.Services.AddEventHubService();
    }
}
