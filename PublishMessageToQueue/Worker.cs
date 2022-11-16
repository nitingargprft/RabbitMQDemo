using DataContext;
using MassTransit;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace PublishMessageToQueue
{
    public class Worker : BackgroundService
    {
        readonly IBus bus;

        public Worker(IBus bus)
        {
            this.bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await this.bus.Publish(new InmateDataModel { InmateId = "001", InmateName = "Steve Smith" }, stoppingToken);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
