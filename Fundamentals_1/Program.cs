using System;

namespace Fundamentals_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // for ( int i  = 1; i < 256; i++){
            //     Console.WriteLine(i);
            // }
            // for (int i = 1; i < 101; i++){
            //     if (i % 3 == 0 && i % 5 != 0 || i % 3 !=0 && i % 5 ==0){
            //         Console.WriteLine(i);
            //     }
                
            // for ( int i = 1; i < 101; i++){
            //     if ( i % 3 == 0 ){
            //         Console.WriteLine("Fizz");
            //     }
            //     if (i % 5 ==0){
            //         Console.WriteLine("Buzz");
            //     }
            //     if ( i %3 == 0 && i % 5 == 0){
            //         Console.WriteLine("FizzBuzz");
            //     }
            // }
            
            Random rand = new Random();
            int i = 0;
            while (i < 10){
               Console.WriteLine (rand.Next(0,10));
                if (rand.Next(0,10) == 0){
                    Console.WriteLine("Wow, you are the first number");
                }
                else if (rand.Next(0,10) == 4){
                    Console.WriteLine(" you are in the middle");
                }
                i++;
            }
        }
    }
}
