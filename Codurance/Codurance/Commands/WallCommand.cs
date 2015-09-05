using Codurance.Services;

namespace Codurance.Commands
{
    public class WallCommand: ICommand
    {
        private readonly IMessageService _messageService;
        private readonly string _userName;

        public WallCommand(IMessageService messageService, string userName)
        {
            _messageService = messageService;
            _userName = userName;
        }

        public void Execute()
        {
            _messageService.GetWall(_userName);
        }
    }
}
