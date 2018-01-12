using System;
using System.Collections.Generic;
namespace boxing
{
    class Program
    {
        public  void SayHello(string name = "Yang Luo")
        {
            Console.WriteLine($"Hello how are you doing today? {name}");
        }
        static void Main(string[] args)
        {   
            Program program = new Program();
            program.SayHello();
        }
    }
}
