using System;
namespace human
{
    public class Samurai:Human
    {   
        public static int count;
        public Samurai():base("Samurai")
        {
            this.health = 200;
            count += 1;
        }
        public  Enemy Death_blow(object A)
        {
            if (A is Enemy)
            {
                Enemy A_a = A as Enemy;
                if ( A_a.health < 50)
                {
                    A_a.health =0;
                    return A_a;
                }
            }
            return null;
        }
        public void Meditate()
        {
            this.health = 200;
            
        }
        public  void How_many()
        {
            Console.WriteLine(count);
        }
    }
}