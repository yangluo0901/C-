using System;
using System.Collections.Generic;
namespace basic_13
{
    class Program
    {
        //Write a program (sets of instructions) that would print all the numbers from 1 to 255.
         public static void Print1()
         {
             for ( int i = 0; i < 255; i++)
             {
                 Console.WriteLine(i+1);
             }
         }   
        //Write a program (sets of instructions) that would print all the odd numbers from 1 to 255.
         public static void Print2()
         {
             for ( int i = 0; i < 255; i+=2)
             {
                 Console.WriteLine(i+1);
             }
         }  
         //Print Sum
        public static void Print3()
         {   int sum  = 0;
             for ( int i = 1; i < 256; i++)
             {   sum+=i;
                 Console.WriteLine($"New number : {i}  Sum: {sum}");
             }
         } 
         //Iterating through an Array
         public static  void Loop_Array(int[] array1) 
         {
             foreach ( var entry in array1)
             {
                 Console.WriteLine(entry);
             }
         }
         //Find Max
         public static void Max(int[] array)
         {
             for ( int i = 0; i < array.Length-1; i++)
             {
                 for ( int j = 1; j < array.Length - i; j++){
                     if ( array[j] < array[j -1]){
                         int temp =  array[j];
                         array[j] = array[j-1];
                         array[j-1] = temp;
                     }
                 }
             }
             foreach ( var entry in array)
             {
                 Console.WriteLine(entry);
             }
         }
         public static void Max1(int[] array)
         {
             for ( int  i = 0; i < array.Length; i++)
             {
                 for ( int j = i +1; j < array.Length; j++)
                 {
                     if ( array[i] > array [j])
                     {
                         int temp = array[i];
                         array[i] = array[j];
                         array[j] = temp;
                     }
                 }
             }
             foreach ( var entry in array)
             {
                 Console.WriteLine(entry);
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
         //Array with Odd Numbers
         public static List<int> Odd(int a , int b)
         {  
             int length = b - a + 1;
             List<int> y = new List<int>();
             for ( int i = 0; i < length; i++){
                 if ( a % 2 != 0){
                     y.Add(a);
                 }
                 a +=1;
             }
            return y;
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
            //   if (arg is int[])
            //   {
            //     string str = "[ " + string.Join(",", arg)+ " ]";
            //     Console.WriteLine(str);
            //   }
            //   else if ( arg is List<int>)
            //   {
            //       string str = "[ " + string.Join(",", arg)+ " ]";
            //        Console.WriteLine(str);
            //   }
          }
          //Greater than Y
          public static void  Great (int arg, int[] array){
              int count = 0;
              foreach ( var entry in array)
              {
                  if ( entry > arg)
                  {
                      count++;
                  }
              }
              Console.WriteLine($"There are {count} numbers that are greater than {arg}");
          }
          //Square the Values
          public static void Square(int [] array)
          {
              for ( int i = 0; i < array.Length; i++)
              {
                  array[i] =  array[i]*array[i];
              }
              Display(array);
          }
          //Eliminate Negative Numbers
          public static void EliminateNegative(int[] array)
          {
              for ( int i = 0; i < array.Length; i++)
              {
                  if ( array[i] < 0)
                  {
                      array[i] = 0;
                  }
              }
              Display(array);
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
          //Number to String
          public static void  Replace(int[] array)
          { 
              string[] array1 = new string[array.Length];
              for ( int i = 0 ; i < array.Length; i++)
              {
                  array1 [i] = array[i].ToString();
                  if (array[i] < 0){
                      array1[i] = "dojo";
                  }
              }
              Display(array1);
          }

        static void Main(string[] args)
        {
           Replace( new int[] {1,3,-5,7,-8, 12,11,6,23});
       
        }
    }
}
