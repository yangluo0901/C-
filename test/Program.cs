using System;
using System.Collections.Generic;
using System.Linq;
namespace test
{
    class Program
    {
        static void Main(string[] args)
        {   
            
            Random rand = new Random();
            string passcode = "";
            for ( int i = 0 ; i < 14; i++)
            {   
                int letter = rand.Next(0,2);
                
                if ( letter ==0 ){
                    string temp = rand.Next(0,10).ToString();
                    passcode = passcode.Insert(i,temp);
                }
                else
                {   
                    char temp =(char)('a'+rand.Next(0,25));
                    string temp1 = temp.ToString();
                    passcode = passcode = passcode.Insert(i,temp1);
                }
            
            }
            Console.WriteLine(passcode);
        }
    }
}
