using System;

namespace Codurance.Infrastructure
{
    public class DateTimeHelper : IDateTimeHelper
    {
        public DateTime CurrentDateTime
        {
            get { return DateTime.UtcNow; }
        }
    }
}
