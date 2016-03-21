using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlingApplicationBlock
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1.测试过滤System.FormatException异常过滤（过滤其他的异常同理）
            //HaveExceptionTest();

            // 2.测试异常转化 FileNotFoundException -> TimeoutException
            //ExceptionReplaceTest();

            // 3.测试包装Exception处理 NullReferenceException Wrap Handler
            //ExceptionWrapTest();

            // 4.测试logging exception
            ExceptionLoggingTest();
        }

        // 测试过滤System.FormatException异常过滤（过滤其他的异常同理）
        static void HaveExceptionTest()
        {
            bool haveException = false;

            ExceptionManager em = EnterpriseLibraryContainer.Current.GetInstance<ExceptionManager>();

            try
            {
                em.Process(NoThrowException, "Policy");
            }
            catch (Exception)
            {
                haveException = true;
                Console.WriteLine("捕获异常！");
            }

            if (haveException == false)
            {
                Console.WriteLine("未捕获到任何异常！");
            }
        }

        static void NoThrowException()
        {
            int i = Int32.Parse("A");
            Console.WriteLine("发生异常，不执行该指令");
        }

        // 测试异常转化 FileNotFoundException -> TimeoutException
        static void ExceptionReplaceTest()
        {
            ExceptionManager em = EnterpriseLibraryContainer.Current.GetInstance<ExceptionManager>();

            try
            {
                em.Process(ReplaceHandler, "Policy");
            }
            catch (TimeoutException e)
            {
                Console.WriteLine("捕获到TimeoutException异常！异常信息：" + e.Message);
            }

        }

        static void ReplaceHandler()
        {
            File.Open("test.txt", FileMode.Open);
            Console.WriteLine("发生异常，不执行该指令");
        }

        // 测试包装Exception处理 NullReferenceException Wrap Handler
        static void ExceptionWrapTest()
        {
            ExceptionManager em = EnterpriseLibraryContainer.Current.GetInstance<ExceptionManager>();

            try
            {
                em.Process(WrapHandler, "Policy");
            }
            catch (ApplicationException e)
            {
                Console.WriteLine("捕获ApplicationException异常，其被包装异常为{0}!", e.InnerException.GetType().ToString());
                Console.WriteLine("异常信息：{0}", e.Message);
            }

        }

        static void WrapHandler()
        {
            Hashtable ht = new Hashtable();
            ht["test"].ToString();
            Console.WriteLine("发生异常，不执行该指令");
        }

        // 测试logging exception
        static void ExceptionLoggingTest()
        {
            ExceptionManager em = EnterpriseLibraryContainer.Current.GetInstance<ExceptionManager>();

            try
            {
                em.Process(NotifyRethrow, "Policy");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("捕获到ArgumentOutOfRangeException异常，并写入日志!");
            }
        }

        static void NotifyRethrow()
        {
            List<string> list = new List<string>();
            string str = list[1];
            Console.WriteLine("发生异常，不执行该指令");
        }

    }
}
