using System;
using System.Collections.Generic;
namespace test
{
    class Program
    {
        static void Main(string[] args)
        {   
            List<int> list = new List<int>(){1,2,3,4};
            int a = list.RemoveAt(1);
            Console.WriteLine(a);
        }
    }
}
