using Codurance.Infrastructure;

namespace Codurance.Commands
{
    public class NullCommand : ICommand
    {
        private readonly IPrinterHelper _printerHelper;

        public NullCommand(IPrinterHelper printerHelper)
        {
            _printerHelper = printerHelper;
        }

        public void Execute()
        {
            _printerHelper.WriteLine("Unrecognized command");
        }
    }
}
