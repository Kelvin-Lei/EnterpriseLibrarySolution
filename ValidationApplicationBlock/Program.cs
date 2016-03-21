using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationApplicationBlock
{
    class Program
    {
        static int index = 1;
        static void Main(string[] args)
        {
            //验证Customer类
            Validator<Customer> customerValidator = ValidationFactory.CreateValidator<Customer>();

            //设置Customer的CustomerName字段为NULL
            Customer myCustomer = new Customer(null);

            ValidationResults vr = customerValidator.Validate(myCustomer);
            Scan(vr);

            //设置Customer的CustomerName
            myCustomer.CustomerName = "coco";

            vr = customerValidator.Validate(myCustomer);
            Scan(vr);

            //创建一个日期
            DateTime dt = new DateTime(1988, 01, 01);

            //创建一个日期验证器
            Validator<DateTime> v1 = new DateTimeRangeValidator(DateTime.Parse("2009-01-01"), DateTime.Parse("2010-01-01"));
            vr = v1.Validate(dt);
            Scan(vr);

            dt = new DateTime(2009, 05, 05);
            vr = v1.Validate(dt);
            Scan(vr);
        }
       
        static void Scan(ValidationResults vr)
        {
            Console.WriteLine("测试{0}：", index++);

            if (!vr.IsValid)
            {
                Console.WriteLine("出错");
            }
            else
            {
                Console.WriteLine("正确");
            }

            Console.WriteLine("-----------------------------------------");
        }
    }

    public class Customer
    {
        [NotNullValidator]
        public string CustomerName;

        public Customer(string customerName)
        {
            this.CustomerName = customerName;
        }
    }
}
