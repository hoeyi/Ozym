using Ozym.Messaging;

namespace Ozym.Test.Messaging
{
    [TestClass]
    [TestCategory("Unit")]
    public class MessageServiceTest
    {
        [TestMethod]
        public void MessageSerivce_MessagePublished_InvokesDelegate()
        {
            // Set-up
            IMessageService service = new MessageService()
            {
            };

            static void Service_ContentPublished(object sender, Message e)
            {
                Assert.IsTrue(e is not null);
            }

            service.ContentPublished += Service_ContentPublished;

            service.Publish("Header", "Body message.");
        }

    }
}
