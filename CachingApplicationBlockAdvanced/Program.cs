using Microsoft.Practices.EnterpriseLibrary.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachingApplicationBlockAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建CacheManager
            CacheManager cacheManager = CacheFactory.GetCacheManager() as CacheManager;

            //添加缓存项
            cacheManager.Add("MyDataReader", "123");

            //获取缓存项
            string str = cacheManager.GetData("MyDataReader").ToString();

            Console.WriteLine(str);

            Console.Read();
        }
    }
}
