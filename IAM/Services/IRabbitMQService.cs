using System;

namespace IAM.Services;

public interface IRabbitMQService
{
     void PublishMessage(string queueName, object message);
}
