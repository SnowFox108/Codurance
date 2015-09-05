
using Codurance.Infrastructure;

namespace Codurance.Services
{
    public interface IMessageService
    {
        void PostMessage(string userName, string text, IDateTimeHelper dateTime);
        void ReadMessage(string userName);
        void GetWall(string userName);
    }
}
