using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingApplicationBlock
{
    class Program
    {
        static void Main(string[] args)
        {
            LogEntry logEntry = new LogEntry();

            logEntry.EventId = 1;
            logEntry.Priority = 1;
            logEntry.Title = "标题党";
            logEntry.Message = "qq.com";
            logEntry.Categories.Add("QQ");
            logEntry.Categories.Add("TENCENT");

            Logger.Writer.Write(logEntry, "General");
            Console.WriteLine("日志写入完成！");

            Console.Read();
        }
    }
}
