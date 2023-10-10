using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using ToDoList_ServiceBus.Repository;

[assembly: FunctionsStartup(typeof(FetchToDoListFunc.Startup))]
namespace FetchToDoListFunc
{
    internal class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            // Access the configuration
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            builder.Services.AddSingleton<IMongoDatabase>(_ =>
            {
                var client = new MongoClient("mongodb://todolistfse:UKGxtoSnOUNQYXYY2BaQhXzazcMcygSL0oSxzGx1wZfTwulbl9B3YHrP5cQRfdA37MY63VcvNP47ACDbKhD1ZQ==@todolistfse.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@todolistfse@");
                return client.GetDatabase("todolist-db");
            });

            builder.Services.AddSingleton<IFetchToDoList, FetchToDoList>();
        }
    }
}
