using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigInterger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("请输入大数字b1（100位以内）：");
            BigInteger b1 = new BigInteger(Console.ReadLine());
            Console.Write("输入大数字b2(100位以内)：");
            BigInteger b2 = new BigInteger(Console.ReadLine());
            Console.Write("b1="); b1.show();
            Console.Write("b2="); b2.show();
            BigInteger b3 = b1 + b2;
            Console.Write("b3=b1+b2="); b3.show();
            BigInteger b4 = b1 - b2;
            Console.Write("b4=b1-b2="); b4.show();
            if (b1 < b2) Console.WriteLine("b1<b2");
            if (b1 > b2) Console.WriteLine("b1>b2");
            if (b1 == b2) Console.WriteLine("b1=b2");
            Console.ReadLine();
        }
    }
}
