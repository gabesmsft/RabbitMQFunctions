using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.Extensions.RabbitMQ;

namespace GabeFakeRabbitMQFunction
{
    //basic RabbitMQ Trigger Function

    // You can either use the ConnectionStringSetting, or use UserNameSetting, PasswordSetting, and HostName. If you specify both, ConnectionStringSetting takes precedent.
    public static class TriggerFunction
    {
        [FunctionName("TriggerFunction")]
        public static void Run([RabbitMQTrigger("queue",
            ConnectionStringSetting = "MyRabbitMQConnectionName"
            //HostName = "%HostNameAppSetting%", UserNameSetting = "%UserNameAppSetting%", PasswordSetting = "%PasswordAppSetting%", ConnectionStringSetting = "MyRabbitMQConnectionName"
            )] string message, ILogger log)
        {
            log.LogInformation($"Message received from RabbitMQ trigger: {message}");
        }
    }
}
