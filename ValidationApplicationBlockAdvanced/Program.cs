using Microsoft.Practices.EnterpriseLibrary.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationApplicationBlockAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            Validator<Customer> customerValidator = ValidationFactory.CreateValidator<Customer>("Validation Ruleset");
            Customer myCustomer = new Customer(null);
            ValidationResults r = customerValidator.Validate(myCustomer);

            if (!r.IsValid)
            {
                for (int i = 0; i < r.Count; i++)
                {
                    Console.WriteLine("出错{0}:" + r.ElementAt(i).Message, i + 1);
                }
            }
            else
            {
                Console.WriteLine("正确");
            }

        }
    }

    public class Customer
    {
        public string CustomerName;

        public Customer(string customerName)
        {
            this.CustomerName = customerName;
        }

        public int Test()
        {
            return -5;
        }
    }
}
