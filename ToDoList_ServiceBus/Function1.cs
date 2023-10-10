using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ToDoList_ServiceBus
{
    public class Function1
    {
        [FunctionName("Function1")]
        public void Run([ServiceBusTrigger("todolist-queue",Connection = "AzurServiceBusConnectionString")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Service Bus queue trigger function processed message: {myQueueItem}");
        }
    }
}
