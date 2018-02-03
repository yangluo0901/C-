using System;
using System.Collections.Generic;
using System.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {   
            
            List<string> names = new List<string>()
            {
                "yang",
                "nicolas",
                "micheal"
            };

            List<string> aaa = names.Where(entry=> entry.Length>4).ToList();
            foreach( var element in aaa)
            {
                Console.WriteLine(element);
            }
            
        }
    }
}
