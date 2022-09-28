namespace backend.Features.Messages.Services;

public interface IMessageService
{
    public IEnumerable<Message> List();
    public Message Create();
}