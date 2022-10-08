namespace NjordFinance.Messaging
{
    /// <summary>
    /// Service responsible for publishing messages to distributed subscribers.
    /// </summary>
    public class MessageService : Publisher<Message>, IMessageService
    {
        public void Publish(string header, string content) =>
            OnPublish(new() { Header = header, Body = content });
    }
}
