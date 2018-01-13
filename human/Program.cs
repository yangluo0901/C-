using System;

namespace human
{   
    class Human
    {
        public string name;
        public int strength = 3;
        public int intelligence = 3;
        public int dexterity = 3;
        public int health = 100;
        public void Human(string name)
        {
            name = name;
        }
        public void Human(string name,int strength, intelligence, dexterity, health)
        {
            name = name;
            strength =  strength;
            intelligence =  intelligence;
            dexterity = dexterity;
            health = health;
        }
        public void Attack(object A)
        {   
            if ( A is Human)
            {
                damage = 5 * strength;
            }
            else
            {
                Console.WriteLine(" It is not a humnabeing");
            }
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
