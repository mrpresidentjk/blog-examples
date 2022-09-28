namespace backend.Features.Messages.Hubs;

public interface IMessageHubClient
{
    public Task MessageCreated(Message message);
}