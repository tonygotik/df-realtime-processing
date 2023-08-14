namespace MessageInboundHandler.Models;

public record MessageInboundModel(string routingKey, string message);
