using System;

namespace Codurance.Infrastructure
{
    public class PrinterHelper : IPrinterHelper
    {
        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}
