using Codurance.Infrastructure.Adatepter;

namespace Codurance.Commands
{
    public abstract class BaseCommandFactory
    {
        protected readonly IDiContainer ServiceLocator;

        protected BaseCommandFactory(IDiContainer serviceLocator)
        {
            ServiceLocator = serviceLocator;
        }
    }
}
