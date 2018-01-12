using System;
using System.Collections.Generic;
namespace test
{
    class Program
    {
        static void Main(string[] args)
        {   
            List<int> list = new List<int>(){1,2,3,4};
            string str = string.Join(",",list);
            Console.WriteLine(str);
        }
    }
}
