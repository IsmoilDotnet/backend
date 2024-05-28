    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using Notification.Hubs;
    using System.Threading.Tasks;

namespace Notification.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post(string message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", message);
            return Ok();
        }
    }

}
