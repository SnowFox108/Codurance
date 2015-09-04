
namespace Codurance.Commands
{
    public interface ICommandFactory
    {
        string CommandName { get; }
        ICommand CreateCommand(string[] arguments);
    }
}
