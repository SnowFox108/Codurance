using Codurance.Data.Model;
using Codurance.Data.Repository;
using Codurance.Infrastructure;
using Codurance.Services;
using Codurance.Services.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;

namespace UnitTest
{
    [TestClass]
    public class MessageServiceTests
    {

        [TestMethod]
        public void CanPostMessage()
        {
            var fixture = new Fixture();
            var mockUser = fixture.Create<User>();

            var mockMessagePrinterService = new Mock<IMessagePrinterService>();            
            var mockUserService = new Mock<IUserService>();
            var mockMessageRepository = new Mock<IMessageRepository>();
            var mockSubscriptionRepository = new Mock<ISubscriptionRepository>();
            var mockDateTimeHelper = new Mock<IDateTimeHelper>();

            mockUserService.Setup(u => u.GetUser(It.IsAny<string>())).Returns(mockUser);

            var messageService = new MessageService(mockMessagePrinterService.Object,
                mockUserService.Object,
                mockMessageRepository.Object,
                mockSubscriptionRepository.Object);

            messageService.PostMessage(fixture.Create<string>(), fixture.Create<string>(), mockDateTimeHelper.Object);

            mockMessageRepository.Verify(m => m.CreateMessage(mockUser, It.IsAny<string>(), mockDateTimeHelper.Object), Times.Once);
        }
    }
}
