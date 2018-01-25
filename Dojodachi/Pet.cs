using System;
using System.Collections.Generic;
namespace DojoDachi
{
    public class Pet
    {
        public int fullness;
        public int happiness;
        public int meal;
        public int energy;
        public Random rand;
        public bool status;
        public  Pet()
        {
            fullness = 20;
            happiness = 20;
            energy = 50;
            meal = 3;
            status = true;
            rand = new Random();
        }
        public bool chance ()
        {
            int chance = rand.Next(0,4);
            if (chance ==0)
            {
                return false; // do not like it
            }
            else
            {
                return true;//like it;
            }
        }
        public int Feed()
        {
            int increment = rand.Next(5,11);
            if (meal >0)
            {
                meal -= 1;
                if (chance())
                {   
                    
                    fullness += increment;
                }
            }
            return increment;
        }
        public int Play()
        {   int increment = rand.Next(5,11);
            if (energy >= 5)
            {
                energy -= 5;
                if (chance())
                {   
                    happiness += increment;
                }
                
            }
            return increment;
            
        }
        public int  Work()
        {   int increment = rand.Next(1,4);
            if(energy >= 5)
            {
                energy -=5;
                meal += increment;
            }
            return increment;
        }
        public Pet Sleep()
        {
            energy += 15;
            fullness -= 5;
            happiness -= 5;
            this.Status();
            return this;
            
        }
        public void Status()
        {
            if ( fullness <1 || happiness < 1)
            {
                status = false;
            }
            else
            {
                status = true;
            }
        }
    }
}