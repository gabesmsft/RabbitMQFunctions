This project contains the following:
<ul>
<li>TriggerFunction.cs: a basic RabbitMQ Trigger Function</li>
<li>TriggerFunctionDLX.cs: a RabbitMQ Trigger Function that is used to demonstrate putting a message into a RabbitMQ poison q (if one is configured on the RabbitMQ end). This Function throws an exception if the message isn't in the format {"x":1,"y":2}</li>
<li>OutputFunction.cs: HTTP Trigger Function that writes a message to a RabbitMQ q. By default, this is set to the same q that TriggerFunction listens on, so if you make an HTTP request to the OutputFunction and the TriggerFunction triggers on the message, this demonstates that the OutputFunction wrote the message to the q.</li>
</ul>