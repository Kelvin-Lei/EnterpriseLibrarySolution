using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyApplicationBlock
{
    class Program
    {
        static void Main(string[] args)
        {
            // App.config中添加hashProviders节点
            test1();

            // App.config中添加symmetricCryptoProviders节点（对称秘钥加密）
            test2();

            Console.Read();
        }

        // App.config中添加hashProviders节点
        static void test1()
        {
            //获取离散码
            string hash = Cryptographer.CreateHash("MD5Cng", "SensitiveData");

            Console.WriteLine(hash);

            Console.WriteLine("-------------------------------------------------");

            bool equal = Cryptographer.CompareHash("MD5Cng", "SensitiveData", hash);

            if (equal)
            {
                Console.WriteLine("正确");
            }
            else
            {
                Console.WriteLine("错误");
            }
        }

        // App.config中添加symmetricCryptoProviders节点（对称秘钥加密）
        static void test2()
        {
            string Encrypt = Cryptographer.EncryptSymmetric("DPAPI Symmetric Crypto Provider", "SensitiveData");

            Console.WriteLine("密文：" + Encrypt);

            Console.WriteLine("--------------------------------------------");

            // 测试数据篡改后效果
            //Encrypt = Encrypt.Replace("A", "B");

            Encrypt = Cryptographer.DecryptSymmetric("DPAPI Symmetric Crypto Provider", Encrypt);

            Console.WriteLine("原文：" + Encrypt);
        }
    }
}
