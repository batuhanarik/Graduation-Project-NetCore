using System;

namespace Business.CCS
{
    public class DbLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("DB loglandı");
        }
    }
}
