using System;
using System.Collections.Generic;
using System.Linq;
namespace test
{
    class Program
    {
        static void Main(string[] args)
        {   
            List<string> StringList = new List<string> {
                              "apple",
                              "banana",
                              "carrot",
                              "asparagus",
                              "tomato",
                              "artichoke"
                          };
            //IEnumerable<string> TransformedList = StringList.Where( str => str[0] == 'a');
            IEnumerable<string> TransformedList = StringList
                                            .Where( str =>  {   if(str[0] == 'a')
                                                                {
                                                                    return true;
                                                                }
                                                                return false;
                                                            });
           foreach ( var entry in TransformedList)
           {
               Console.WriteLine(entry);
           }
        }
    }
}
