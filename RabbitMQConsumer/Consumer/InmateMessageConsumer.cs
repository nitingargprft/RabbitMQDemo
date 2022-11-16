using DataContext;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQConsumer.Consumer
{
    public class InmateMessageConsumer : IConsumer<InmateDataModel>
    {
        readonly ILogger<InmateMessageConsumer> logger;

        public InmateMessageConsumer()
        {

        }

        public Task Consume(ConsumeContext<InmateDataModel> context)
        {
            string message = string.Format("Hello {0} {1}", context.Message.InmateId, context.Message.InmateName);
            Console.WriteLine(message);
            return Task.CompletedTask;
        }

    }

}
