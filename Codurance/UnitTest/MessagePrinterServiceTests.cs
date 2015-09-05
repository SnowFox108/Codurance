using System;
using System.Collections.Generic;
using System.Linq;
using Codurance.Data.Model;
using Codurance.Infrastructure;
using Codurance.Services.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;

namespace UnitTest
{
    [TestClass]
    public class MessagePrinterServiceTests
    {
        [TestMethod]
        public void CanPrintMessage()
        {
            var fixture = new Fixture();
            var messages = fixture.CreateMany<Message>(5);

            var mockDateTimeHelper = new Mock<IDateTimeHelper>();
            var mockPrinterHelper = new Mock<IPrinterHelper>();

            mockDateTimeHelper.Setup(d => d.CurrentDateTime).Returns(DateTime.UtcNow);

            var messagePrinterService = new MessagePrinterService(mockDateTimeHelper.Object, mockPrinterHelper.Object);

            messagePrinterService.PrintMessage(messages);

            mockPrinterHelper.Verify(p => p.WriteLine(It.IsAny<string>()), Times.Exactly(5));
        }

        [TestMethod]
        public void CanPrintMessageDescByDate()
        {
            var fixture = new Fixture();
            var messages = fixture.CreateMany<Message>(5);
            var results = new List<string>();

            var mockDateTimeHelper = new Mock<IDateTimeHelper>();
            var mockPrinterHelper = new Mock<IPrinterHelper>();

            mockDateTimeHelper.Setup(d => d.CurrentDateTime).Returns(DateTime.UtcNow);
            mockPrinterHelper.Setup(p => p.WriteLine(It.IsAny<string>())).Callback<string>(s => results.Add(s));

            var messagePrinterService = new MessagePrinterService(mockDateTimeHelper.Object, mockPrinterHelper.Object);

            messagePrinterService.PrintMessage(messages);


            Assert.IsTrue(results[0].Contains(messages.OrderByDescending(m => m.CreatedDate).ElementAt(0).Text));
            Assert.IsTrue(results[1].Contains(messages.OrderByDescending(m => m.CreatedDate).ElementAt(1).Text));
            Assert.IsTrue(results[2].Contains(messages.OrderByDescending(m => m.CreatedDate).ElementAt(2).Text));
            Assert.IsTrue(results[3].Contains(messages.OrderByDescending(m => m.CreatedDate).ElementAt(3).Text));
            Assert.IsTrue(results[4].Contains(messages.OrderByDescending(m => m.CreatedDate).ElementAt(4).Text));

        }
    }
}
