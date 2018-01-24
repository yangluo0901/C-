using System;
using System.Collections.Generic;
using System.Linq;
namespace simple_crud

{   
    class Function
    {
        public static void Read(List<Dictionary<string, object>> a)
        {   
             
                string str = "";
                foreach ( var key in a[0].Keys)
                {
                   str += key+"\t";
                }
                Console.WriteLine(str);
                
                foreach (var entry in a)
                {   string str2 = "";
                    foreach ( var value in entry.Values)
                    {
                        str2 += value+"\t     ";
                    }
                    Console.WriteLine(str2);
                }
        }
        public static void Create()
        {
            Console.WriteLine("Create new instance? type (yes/no)");
            string confir = Console.ReadLine();
            if ( confir == "yes")
            {
                Console.WriteLine("Please input first name:");
                string first_name =  Console.ReadLine();
                Console.WriteLine("Last name:");
                string last_name = Console.ReadLine();
                Console.WriteLine("Favorite Number:");
                string favoritenumber = Console.ReadLine();
                String query =  $"INSERT INTO users(first_name,last_name,favoritenumber,created_at,updated_at) VALUES ('{first_name}','{last_name}',{favoritenumber},NOW(),NOW())";
                Console.WriteLine(query);
                List<Dictionary<string, object>>A = DbConnector.Query(query);
                Console.WriteLine("Added!");
                
            }
            else
            {
                Console.WriteLine("Next time !");
                
            }
        }
        public static void Update()
        {
            string query = "UPDATE users SET";
            string query_firstname = "";
            string query_lastname = "";
            string query_favoritenumber = "";
            bool a =false;
            bool c = false;
            bool b = false;
            Console.WriteLine("Want to update database? (yes/no)");
            string confir = Console.ReadLine();
            if ( confir == "yes")
            {   
                Console.WriteLine("Which user do you want to update ? (type in user ID)");
                string ID = Console.ReadLine();
                var temp1 = DbConnector.Query($"SELECT COUNT(id) FROM users WHERE id = {ID}");//check if this user exists, by using Count(), return List<Dictionary<string,object>>
                List<object> temp2 = temp1[0].Values.ToList();  //get first value which is number of how many matches, USING SYSTEM.LINQ IN ORDER TO USE ToList() to convert KeyCollction to List
                int existance = Convert.ToInt32(temp2[0]); //Error:"Unable to cast object of type 'System.Int64' to type 'System.Int32'."
                if (existance != 0)
                {
                    Console.WriteLine("want to update first name?(type first name or just type no)");
                    string first_name = Console.ReadLine();
                    if ( first_name != "no")
                    {
                        query_firstname = $" first_name = '{first_name}'";
                    }
                    else
                    {
                         a = true;
                    }
                    Console.WriteLine("want to update last name?(type last name or no)");
                    string last_name = Console.ReadLine();
                    if (last_name != "no")
                    {
                        query_lastname = $" ,last_name = '{last_name}'";
                    }
                    else
                    {
                        b = true;
                    }
                    Console.WriteLine("want to update favorite number(type number or no)");
                    string favoritenumber = Console.ReadLine();
                    if ( favoritenumber != "no")
                    {
                        query_favoritenumber =$" ,favoritenumber = {favoritenumber}";
                    }
                    else
                    {
                        c = true;
                    }


                    if ( a && b && c)
                    {
                        Console.WriteLine(" You did not input, update fails !");
                    }
                    else
                    {
                        query = query + query_firstname +query_lastname+query_favoritenumber+$" WHERE id = {ID}";   
                        Console.WriteLine(query);
                        DbConnector.Query(query);  
                    }
                }
                else
                {
                    Console.WriteLine("Record does not exist!");
                }
                
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {   
          Function.Update();
            // var a = DbConnector.Query("SELECT COUNT(id) FROM users WHERE id = 20");
        
            // int b =  a.Count;
            // // foreach( var entry in a[0].Values)
            // // {
            // //     Console.WriteLine(entry);
            // // }
            // List<object> c = a[0].Values.ToList();
            // int d = (int)(long)c[0];
            // Console.WriteLine(d);
            
            
         
        }
    }
}
