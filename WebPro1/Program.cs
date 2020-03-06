using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPro1
{
    class Program
    {
        static void Main(string[] args)
        {
            WebReference.WebServiceDemo webservice = new WebReference.WebServiceDemo();
            string a = "2";
            string b = "3";

            Console.WriteLine(webservice.HelloWorld());
            Console.WriteLine(a + "+" + b + "=" + webservice.Add(a, b));
            Console.WriteLine(a + "*" + b + "=" + webservice.Sum(a, b));

            Console.ReadKey();
        }
    }
}
