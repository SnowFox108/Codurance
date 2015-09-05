using System.Linq;
using Codurance.Data.Repository;
using Codurance.Infrastructure;
using Codurance.Services.Shared;

namespace Codurance.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessagePrinterService _messagePrinterService;
        private readonly IUserService _userService;
        private readonly IMessageRepository _messageRepository;
        private readonly ISubscriptionRepository _subscriptionRepository;

        public MessageService(IMessagePrinterService messagePrinterService, IUserService userService, IMessageRepository messageRepository, ISubscriptionRepository subscriptionRepository)
        {
            _userService = userService;
            _messageRepository = messageRepository;
            _subscriptionRepository = subscriptionRepository;
            _messagePrinterService = messagePrinterService;
        }

        public void PostMessage(string userName, string text, IDateTimeHelper dateTime)
        {
            var user = _userService.GetUser(userName);
            _messageRepository.CreateMessage(user, text, dateTime);
        }

        public void ReadMessage(string userName)
        {
            var user = _userService.GetUser(userName);
            var messages = _messageRepository.GetMessages(user);
            _messagePrinterService.PrintMessage(messages);
        }

        public void GetWall(string userName)
        {
            var user = _userService.GetUser(userName);
            
            var subscribedUsers = _subscriptionRepository.GetSubscribers(user).ToList();
            subscribedUsers.Add(user);

            var messages = _messageRepository.GetMessages(subscribedUsers);
            _messagePrinterService.PrintWall(messages);
        }
    }
}
