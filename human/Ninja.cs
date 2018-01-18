using System;
namespace human
{
    public class Ninja:Human
    {
        public Ninja( ):base("Ninja")
        {   
            
            this.dexterity = 175;
        }
        public void Steal(Enemy B)
        {
            this.health += 10;
            B.health -=10;
            Console.WriteLine(B.name+"'s HP is "+ B.health);
            Console.WriteLine(this.name+"'s HP is "+ this.health);
        }
        public void Get_away()
        {
            this.health -= 15;
            Console.WriteLine(this.name+"'s HP is "+ this.health);
        }
            
    }
}