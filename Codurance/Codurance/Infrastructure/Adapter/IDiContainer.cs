
namespace Codurance.Infrastructure.Adapter
{
    public interface IDiContainer
    {
        TService GetInstance<TService>() where TService : class;
    }
}
