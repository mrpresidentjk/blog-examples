using backend.Features.Messages.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Features.Messages.Controllers;

[ApiController]
[Route("[controller]")]
public class MessagesController : ControllerBase
{
    private readonly IMessageService _messageService;

    public MessagesController(IMessageService messageService)
    {
        _messageService = messageService;   
    }

    [HttpGet(Name = "GetMessages")]
    public IEnumerable<Message> Get()
    {
        return _messageService.List();
    }
}
