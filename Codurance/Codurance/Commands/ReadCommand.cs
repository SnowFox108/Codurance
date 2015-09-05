using Codurance.Services;

namespace Codurance.Commands
{
    public class ReadCommand : ICommand
    {
        private readonly IMessageService _messageService;
        private readonly string _userName;

        public ReadCommand(IMessageService messageService, string userName)
        {
            _messageService = messageService;
            _userName = userName;
        }

        public void Execute()
        {
            _messageService.ReadMessage(_userName);
        }
    }
}
