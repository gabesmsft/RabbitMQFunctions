using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GabeFakeRabbitMQFunction
{
    /* HTTP Trigger Function with RabbitMQ output binding
     An HTTP request to this Function should cause the Function to write a message to the specified RabbitMQ queue

    You can either use the ConnectionStringSetting, or use UserName, Password, and HostName. If you specify both, ConnectionStringSetting takes precedent. 
     */
    public static class OutputFunction
    {
        [FunctionName("OutputFunction")]
        public static void Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req, [RabbitMQ(
            QueueName = "queue",
           // ConnectionStringSetting = "MyRabbitMQConnectionName"
           UserName = "UserNameAppSetting", Password = "PasswordAppSetting", HostName = "%HostNameAppSetting%", ConnectionStringSetting = "MyRabbitMQConnectionName"
            )] out string outputMessage, ILogger log)
        {
            log.LogInformation($"C# Http trigger function executed at: {DateTime.Now}");
            outputMessage = "OutputFunction created a message in the RabbitMQ queue. Writing the UTC timestamp of message creation via code: " + DateTime.UtcNow;
        }
    }
}
