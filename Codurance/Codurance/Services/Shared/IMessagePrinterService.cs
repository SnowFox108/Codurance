using System.Collections.Generic;
using Codurance.Data.Model;

namespace Codurance.Services.Shared
{
    public interface IMessagePrinterService
    {
        void PrintMessage(IEnumerable<Message> messages);
        void PrintWall(IEnumerable<Message> messages);
    }
}
