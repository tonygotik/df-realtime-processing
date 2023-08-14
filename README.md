# df-realtime-processing

![image](https://github.com/tonygotik/df-realtime-processing/assets/120072085/14224a19-70b1-494e-af89-4728b71997fe)

Realtime-processing is handle the step 1 & 2 in architecture, that receives message/data via Azure Service Bus and send to Azure Event Hub.

In the Azure Event Hub we will capture the data then create a file in Azure Data Lake 2 as parquet file as here https://learn.microsoft.com/en-us/azure/event-hubs/event-hubs-capture-enable-through-portal.
