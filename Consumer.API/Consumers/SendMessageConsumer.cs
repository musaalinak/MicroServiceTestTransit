using MassTransit;
using Messaging.Contracts;

namespace Consumer.API.Consumers
{
    public class SendMessageConsumer : IConsumer<SendMessage>
    {
        private readonly ILogger<SendMessageConsumer> logger;

        public SendMessageConsumer(ILogger<SendMessageConsumer> logger)
        {
                this.logger = logger;
        }
        public async Task Consume(ConsumeContext<SendMessage> context)
        {
            this.logger.LogInformation($"Message:{context.Message.message}, messageId: {context.MessageId}");
            await Task.CompletedTask;
        }
    }
}
