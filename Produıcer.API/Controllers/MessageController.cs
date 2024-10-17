using MassTransit;
using Messaging.Contracts;
using Messaging.RabbitMqConsts;
using Microsoft.AspNetCore.Mvc;

namespace Produıcer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly ISendEndpointProvider sendEndpointProvider;

        public MessageController(ISendEndpointProvider sendEndpointProvider)
        {
                this.sendEndpointProvider = sendEndpointProvider;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitMessage()
        {
            var uri = new Uri($"queue:{QueueTypes.SendMessageQueue}");

            //api endpoint benzer broker endpoint tanımı
            var endpoint=await this.sendEndpointProvider.GetSendEndpoint(uri);

            await endpoint.Send(new SendMessage("Mesaj"));

            return Ok();
        }
    }
}
