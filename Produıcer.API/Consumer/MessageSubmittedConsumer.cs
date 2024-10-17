using MassTransit;
using Messaging.Contracts;

namespace Produıcer.API.Consumer
{
    public class MessageSubmittedConsumer : IConsumer<MessageSubmitted>
    {
        public async Task Consume(ConsumeContext<MessageSubmitted> context)
        {
            await Task.CompletedTask;
        }
    }
}
