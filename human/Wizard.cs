using System;
namespace human
{
    public class Wizard:Human
    {
       public Wizard():base("Wizard")
       {
           this.health = 50;
           this.intelligence = 25;
       } 
       public Wizard Heal(Human A)
       {
           A.health += intelligence;
           Console.WriteLine(A.name+"'s HP is "+ A.health);
           return this;
       }
       public void Fireball( object A)
       {    
           Random rand =  new Random();
           if ( A is Enemy)
           {    
               Enemy A_a = A as Enemy;
               A_a.health -= rand.Next(20,50);
               Console.WriteLine(A_a.name+"'s HP is "+ A_a.health);
           }
       }
    }
}