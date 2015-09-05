using Codurance.Infrastructure;
using Codurance.Services;

namespace Codurance.Commands
{
    public class PostCommand : ICommand
    {
        private readonly IMessageService _messageService;
        private readonly IDateTimeHelper _dateTimeHelper;
        private readonly string _userName;
        private readonly string _text;

        public PostCommand(IMessageService messageService, string userName, string text, IDateTimeHelper dateTimeHelper)
        {
            _userName = userName;
            _text = text;
            _dateTimeHelper = dateTimeHelper;
            _messageService = messageService;
        }

        public void Execute()
        {
            _messageService.PostMessage(_userName, _text, _dateTimeHelper);
        }
    }
}
