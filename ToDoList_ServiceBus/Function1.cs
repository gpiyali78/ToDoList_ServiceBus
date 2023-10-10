using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ToDoList_ServiceBus.Repository;

namespace ToDoList_ServiceBus
{
    public class Function1
    {
        private readonly IFetchToDoList _fetchRepo;
        public Function1(IFetchToDoList fetchRepo)
        {
            _fetchRepo = fetchRepo;
        }
        [FunctionName("Function1")]
        public void Run([ServiceBusTrigger("todolist-queue",Connection = "AzurServiceBusConnectionString")] TaskList input, ILogger log)
        {
            try
            {
                log.LogInformation($"C# Service Bus queue trigger function processed message: {input}");
               // var reqBody = new StreamReader(myQueueItem).ReadToEnd();
               // var input = JsonConvert.DeserializeObject<TaskList>(reqBody);
                var task = new TaskList
                {
                    //TaskId=input.TaskId,
                    TaskName = input.TaskName,
                    Description = input.Description,
                    TaskStartDate = input.TaskStartDate,
                    TaskEndDate = input.TaskEndDate,
                    TaskStatus = input.TaskStatus,
                    TotalEffortRequired = input.TotalEffortRequired
                };
                _fetchRepo.CreateAsync(task);
            }
            catch(Exception ex)
            {
                log.LogError(ex.Message);
            }
        }
    }
}
