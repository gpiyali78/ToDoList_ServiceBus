using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoList_ServiceBus.Repository
{
    public interface IFetchToDoList
    {
        Task<List<TaskList>> GetAllAsync();
        Task<int> GetLatestTaskIdAsync();
        Task<TaskList> GetTaskDetailsByTaskIdAsync(ObjectId taskId);
        Task<ActionResult<TaskList>> GetTaskDetailsByTaskNameAsync(string taskName);
        Task<ActionResult> CreateAsync(TaskList toDolist);
        Task<ActionResult> UpdateTaskStatusAsync(ObjectId taskID);
        Task<ActionResult> DeleteTaskAsync(ObjectId taskId);
    }
}
