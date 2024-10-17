using MassTransit;
using Messaging.Contracts;

namespace Consumer.API.Consumers
{
    public class SendMessageConsumer : IConsumer<SendMessage>
    {
        private readonly ILogger<SendMessageConsumer> logger;
        private readonly IPublishEndpoint publishEndpoint;
        public SendMessageConsumer(ILogger<SendMessageConsumer> logger, IPublishEndpoint publishEndpoint)
        {
            this.logger = logger;
            this.publishEndpoint = publishEndpoint;
        }
        public async Task Consume(ConsumeContext<SendMessage> context)
        {
            this.logger.LogInformation($"Message:{context.Message.message}, messageId: {context.MessageId}");

            //burada integration event fırlatıldı.
            //sistemler arası haberleşme eventi.
            await this.publishEndpoint.Publish(new MessageSubmitted(context.Message.message));
        }
    }
}
