using System;
using System.Collections.Generic;
using System.Linq;
namespace collections_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            // //Create an array to hold integer values 0 through 9
            int [] array = new int [10];
            for ( int i = 0; i < 10; i++)
            {
                array[i] = i;
            }
            //Create an array of the names "Tim", "Martin", "Nikki", & "Sara"
            array[] array2 = new array[4]{"Tim", "Martin", "Nikki", "Sara"};
            //Create an array of length 10 that alternates between true and false values, starting with true
            string [] array2 = new string [10];
            for ( int i =0; i < 10; i++)
            {
                if ( i % 2 == 1 )
                {
                    array2[i] = "False";
                }
                else if ( i % 2 == 0)
                {
                    array2[i] = "True";
                }
            }
            foreach (var entry in array2)
            {
                Console.WriteLine(entry);
            }
            //With the values 1-10, use code to generate a multiplication table 
            int [,] array3 = new int [10,10];
            for ( int i = 1; i < 11; i++)
            {   
                string str = "[ ";
                for (int j = 1; j < 11; j++)
                {   array3 [i-1,j-1] = i*j;
                    str += i*j;
                    str += ", ";
                }
                str += " ]";
                Console.WriteLine(str);
            }
            foreach (var entry in array3)
            {
                Console.WriteLine(entry);
            }
            //Create a list of Ice Cream flavors that holds at least 5 different flavors (feel free to add more than 5!)
            List<string> flavors = new List<string>();
            flavors.Add("green tea");
            flavors.Add("vanila");
            flavors.Add("chocolate");
            flavors.Add("Mocha");
            flavors.Add("cookies");
           //Output the length of this list after building it
            Console.WriteLine(flavors.Count);
            
            //Output the third flavor in the list, then remove this value.
            Console.WriteLine(flavors[2]);
            flavors.RemoveAt(2);
            //Output the new length of the list (Note it should just be one less~)
            Console.WriteLine(flavors.Count);
            //Create a Dictionary that will store both string keys as well as string values
            Dictionary <string,string> dict1 = new Dictionary <string,string>();
            dict1.Add("Name","ekko");
            dict1.Add("gender","male");
            dict1.Add("role","assasinator");
            dict1.Add("Tim",null);
            dict1.Add("Martin", null);
            dict1.Add("Sara",null);
            // Console.WriteLine(dict1.Keys.GetType());
            For each name key, select a random flavor from the flavor list above and store it as the value
            foreach (var entry in dict1.Keys)
            {
                Console.WriteLine(entry);
                
            }
            Random rand = new Random();
            for ( int i = 3; i < 6; i++)
            {   
                
                int a =  rand.Next(0,5);
                var item  =  dict1.ElementAt(i);
                //Console.WriteLine(item.Key);
                dict1[item.Key] = flavors[a];
            }
            //Loop through the Dictionary and print out each user's name and their associated ice cream flavor.
            foreach (var entry in dict1)
            {
                Console.WriteLine(entry.Key+" : " +entry.Value);
            }
            

        }
    }
}
