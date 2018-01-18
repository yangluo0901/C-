using System;
namespace human
{
    public class Human
    {
    
        public string name;
        public int strength = 3;
        public int intelligence = 3;
        public int dexterity = 3;
        public int health = 100;
        public  Human(string name)
        {
            this.name = name;
            this.strength = 3;
            this.intelligence = 3;
            this.dexterity = 3;
            this.health = 100;
        }
        public  Human(string name,int strength, int intelligence, int dexterity, int health)
        {
            this.name = name;
            this.strength =  strength;
            this.intelligence =  intelligence;
            this.dexterity = dexterity;
            this.health = health;
        }
        public void Attack(object A)
        {   
            if ( A is Human)
            {
               int damage = 5 * strength;
            }
            else
            {
                Console.WriteLine(" It is not a humnabeing");
            }
            
        }
    }
}