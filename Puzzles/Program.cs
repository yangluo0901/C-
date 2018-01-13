using System;
using System.Collections.Generic;
namespace Puzzles
{
    class Program
    {   
        public static void daf(){

        }
        // Display
        public static void Display (object arg) 
        { 
            if(arg.GetType() == typeof(int[]))
            {
                int [] ExplicitArray = arg as int [];
                string str = "[ " + string.Join(",", ExplicitArray)+ " ]";
                Console.WriteLine(str);
            }
            else if (arg.GetType() == typeof(List<int>))
            {   
                List<int> ExplicitList = arg as List<int>;
                string str = "[ " + string.Join(",", ExplicitList)+ " ]";
                Console.WriteLine(str);
            }
            else if (arg.GetType() == typeof(string[]))
            {   
                string[] Explicitstring = arg as string[];
                string str = "[ " + string.Join(",", Explicitstring)+ " ]";
                Console.WriteLine(str);
            }
        }
        //Get Average
        public static float  Average(int [] array)
        {
            float sum = 0;
            foreach ( var entry in array)
            {
                sum += entry;
            }
            Console.WriteLine(sum/array.Length);
            return sum/array.Length;
        }
        //Min, Max, and Average
        //bubble sort
        public static void Sort(int[] array)
        {
            for ( int i = 0; i < array.Length-1; i++)
            {
                for ( int j = 1; j < array.Length - i; j++)
                {
                    if ( array[j] <  array[j - 1])
                    {
                        int temp =  array[j];
                        array[j] = array[j -1];
                        array[j-1] =  temp;
                    }
                }
            }
            Display(array);
            int last =  array[array.Length -1];
            int first = array[0];
            float avg = Average(array);
            Console.WriteLine($"the minimum is {first}, and maximum is {last}, average is {avg}");
        }
        //Random Array
        public static void RandomArray(int n)
        {   
            int[] array =  new int[n];
            Random rand =  new Random();
            for ( int i = 0; i < n; i++)
            {
                array[i] = rand.Next(5,26);
            }
            Display(array);
            Sort(array);
        }
        //Coin Flip
        public static void TossCoin(){
            Console.WriteLine("Tossing a Coin !");
            Random rand =  new Random();
            int c = rand.Next(0,2);
            Console.WriteLine(c);
            if(c == 1){
                Console.WriteLine("Head");
            }
            else{
                Console.WriteLine("Tail");
            }
        }
        public static void TossMultipleCoins (int n)
        {
            for ( int i = 0; i < n; i++)
            {
                TossCoin();
            }
        }
        //Name
        public static List<string> Names(string[] array)
        {   
            List<string> list = new List<string>;
            foreach (var entry in array)
            {
                if (entry.Length > 5)
                {
                    list.Add(entry);
                }
            }
            return list;
        }
        static void Main(string[] args)
        {
            TossMultipleCoins(10);
        }
    }
}
