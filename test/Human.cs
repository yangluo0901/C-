using System;
using System.Collections.Generic;
namespace test
{
    public class Human
    {
        private string name;
        public string namereadonly
        {
            get{return name;}
        }
        public string bday;
        
        public Human(string name, string bday)
        {
            this.name = name;
            this.bday = bday;
        }
    }
}