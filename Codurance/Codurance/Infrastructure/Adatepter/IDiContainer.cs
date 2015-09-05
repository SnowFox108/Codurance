
namespace Codurance.Infrastructure.Adatepter
{
    public interface IDiContainer
    {
        TService GetInstance<TService>() where TService : class;
    }
}
