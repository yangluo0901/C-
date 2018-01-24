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
        public  Pet()
        {
            fullness = 20;
            happiness = 20;
            energy = 50;
            meal = 3;
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
        public Pet Feed()
        {
            if (meal >0)
            {
                meal -= 1;
                if (chance())
                {
                    fullness += rand.Next(5,11);
                }
            }
            
            return this;
        }
        public Pet Play()
        {
            if (energy >= 5)
            {
                energy -= 5;
                if (chance)
                {
                    happiness += rand.Next(5,11);
                }
                return this;
            }
            
        }
        public Pet  Work()
        {
            if(energy >= 5)
            {
                energy -=5;
                meal += rand.Next(1,4);
            }
            return this;
        }
        public Pet Sleep()
        {
            energy += 15;
            fullness -= 5;
            happiness -= 5;
            return this;
        }
    }
}