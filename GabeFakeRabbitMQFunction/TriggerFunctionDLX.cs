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
    /* RabbitMQ Trigger Function used to demonstrate a RabbitMQ message going into poison queue.
    If the message isn't in the format {"x":1, "y":2}, it will cause a Newtonsoft.Json.JsonReaderException at Newtonsoft.Json.JsonTextReader.ParseValue” exception
    and the message will end up the RabbitMQ poison queue (if one is set up on the RabbitMQ end)
    */

    public static class TriggerFunctionDLX
    {
        [FunctionName("TriggerFunctionDLX")]
        public static void RabbitMQTrigger_JsonToPOCO(
    [RabbitMQTrigger("queue2",
            ConnectionStringSetting = "MyRabbitMQConnectionName"
            )] TestClass pocObj, ILogger logger)
        {
            logger.LogInformation($"RabbitMQ queue trigger function processed message: {pocObj}");
        }
    }

    public class TestClass
    {
        public int x, y;

        public TestClass(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
