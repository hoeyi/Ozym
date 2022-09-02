namespace NjordFinance.Messaging
{
    public interface IMessageService : IPublisher<Message>
    {
        /// <summary>
        /// Publishes a new message with the given content as the body.
        /// </summary>
        /// <param name="header">The text header for the message.</param>
        /// <param name="content">The body content for the message.</param>
        void Publish(string header, string content);
    }
}
