using backend.Features.Messages.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace backend.Features.Messages.Services;

public class TimedBroadcastService : BackgroundService
{

    private readonly IMessageService _messageService;
    private readonly IHubContext<MessageHub, IMessageHubClient> _hubContext;

    public TimedBroadcastService(IMessageService messageService, IHubContext<MessageHub, IMessageHubClient> hubContext)
    {
        _messageService = messageService;
        _hubContext = hubContext;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var message = _messageService.Create();
            await _hubContext.Clients.All.MessageCreated(message);
            await Task.Delay(3000);
        }
    }

}