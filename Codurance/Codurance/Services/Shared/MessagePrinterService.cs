using System;
using System.Collections.Generic;
using System.Linq;
using Codurance.Data.Model;
using Codurance.Infrastructure;
using Humanizer;

namespace Codurance.Services.Shared
{
    public class MessagePrinterService : IMessagePrinterService
    {
        private readonly IDateTimeHelper _dateTimeHelper;
        private readonly IPrinterHelper _printerHelper;

        public MessagePrinterService(IDateTimeHelper dateTimeHelper, IPrinterHelper printerHelper)
        {
            _dateTimeHelper = dateTimeHelper;
            _printerHelper = printerHelper;
        }

        public void PrintMessage(IEnumerable<Message> messages)
        {
            DateTime now = _dateTimeHelper.CurrentDateTime;
            foreach (var message in messages.OrderByDescending(m => m.CreatedDate))
            {
                string humanizedTimeSpan = GetHumanizedTimeSpan(now.Subtract(message.CreatedDate));
                var formattedMessage = string.Format("{0} ({1} ago)", message.Text, humanizedTimeSpan);
                _printerHelper.WriteLine(formattedMessage);
            }
        }

        public void PrintWall(IEnumerable<Message> messages)
        {
            DateTime now = _dateTimeHelper.CurrentDateTime;
            foreach (var message in messages.OrderByDescending(m => m.CreatedDate))
            {
                string humanizedTimeSpan = GetHumanizedTimeSpan(now.Subtract(message.CreatedDate));
                var formattedMessage = string.Format("{0} - {1} ({2} ago)", message.CreatedBy.Name, message.Text, humanizedTimeSpan);
                _printerHelper.WriteLine(formattedMessage);
            }
        }

        private string GetHumanizedTimeSpan(TimeSpan relativeTime)
        {
            if (relativeTime.Days > 0)
            {
                return TimeSpan.FromDays(relativeTime.Days).Humanize();
            }
            if (relativeTime.Hours > 0)
            {
                return TimeSpan.FromHours(relativeTime.Hours).Humanize();
            }
            if (relativeTime.Minutes > 0)
            {
                return TimeSpan.FromMinutes(relativeTime.Minutes).Humanize();
            }
            return TimeSpan.FromSeconds(relativeTime.Seconds).Humanize();
        }

    }
}
