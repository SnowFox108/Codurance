
namespace Codurance.Commands
{
    public interface ICommandParser
    {
        ICommand Parse(string input);
    }
}
