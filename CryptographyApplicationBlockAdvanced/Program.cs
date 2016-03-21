using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyApplicationBlockAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            string Encrypt = Cryptographer.EncryptSymmetric("RC2CryptoServiceProvider", "Hello,World! ---你好，世界！");

            Console.WriteLine("密文：" + Encrypt);

            Console.WriteLine("---------------------------------------------------");

            Encrypt = Cryptographer.DecryptSymmetric("RC2CryptoServiceProvider", Encrypt);

            Console.WriteLine("原文：" + Encrypt);
        }
    }
}
