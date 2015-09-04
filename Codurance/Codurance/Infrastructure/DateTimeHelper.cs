using System;

namespace CrossCutting.Infrastructure
{
    public class DateTimeHelper : IDateTimeHelper
    {
        public DateTime CurrentDateTime
        {
            get { return DateTime.UtcNow; }
        }
    }
}
