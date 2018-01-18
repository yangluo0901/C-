using System;
using System.Collections.Generic;
namespace human
{   
  
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary <string,Human> alliance = new Dictionary <string,Human>();
            Dictionary <string,Enemy> enemy = new Dictionary <string,Enemy>();
            Console.WriteLine("Start a new game ?");
            string input  =  Console.ReadLine();
            if ( input == "yes")
            {
                Wizard w1 =  new Wizard();
                Ninja n1 = new Ninja();
                Samurai s1 = new Samurai();
                Zombie z1 =  new Zombie("z1");
                Zombie z2 =  new Zombie("z2");
                Spider sp1 = new Spider("spider1",2,150);
                alliance.Add("w1",w1);
                alliance.Add("n1",n1);
                alliance.Add("s1",s1);
                enemy.Add("z1", z1);
                enemy.Add("z2",z2);
                enemy.Add("spider1",sp1);
                Console.WriteLine("Game start !\n Alliance: 1 Wizard: w1 \t 1 Ninja: n1 \t 1 Samurai: s1\n Enemy: 2 Zombies: z1,z2 \t 1 Spider spider1\nPlease input  ally");
                string ally = Console.ReadLine();
                Console.WriteLine("please input ability");
                string ability = Console.ReadLine();
                Console.WriteLine("Please input target");
                string target = Console.ReadLine();
                if ( ally == "w1") // Wizard abilities:
                {
                    if (ability == "heal")
                    {   
                        if (alliance.ContainsKey(target) == true)
                        {
                            switch (target)
                            {
                                case "w1":
                                    w1.Heal(w1);
                                    break;
                                case "n1":
                                    w1.Heal(n1);
                                    break;
                                case "s1":
                                    w1.Heal(s1);
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("This ability can only be used to ally !");
                        }
                        
                    }
                    else if(ability == "fireball")
                    {
                       if (enemy.ContainsKey(target) == true)
                        {
                            switch (target)
                            {
                                case "z1":
                                    w1.Fireball(z1);
                                    break;
                                case "z2":
                                    w1.Fireball(z2);
                                    break;
                                case "spider1":
                                    w1.Fireball(sp1);
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("This ability can only be used to enemy!");
                        } 
                    }
                }
                else if ( ally == "n1") //Ninja abilities:
                {
                    if (ability == "steal")
                    {
                       if (enemy.ContainsKey(target) == true)
                        {
                            switch (target)
                            {
                                case "z1":
                                    n1.Steal(z1);
                                    break;
                                case "z2":
                                    n1.Steal(z2);
                                    break;
                                case "spider1":
                                    n1.Steal(sp1);
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("This ability can only be used to enemy !");
                        }  
                    }
                    else if (ability == "get_away")
                    {
                       if ( target == "n1")
                       {
                           n1.Get_away();
                       }
                       else
                       {
                           Console.WriteLine("This ability can only be used to self !");
                       }
                    }
                }
                else if ( ally =="s1")
                {   
                    if (ability == "death_blow")
                    {
                        if (alliance.ContainsKey(target) == true)
                        {
                            switch (target)
                            {
                                case "w1":
                                    s1.Death_blow(w1);
                                    break;
                                case "n1":
                                    s1.Death_blow(n1);
                                    break;
                                case "s1":
                                    s1.Death_blow(s1);
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("This ability can only be used to ally !");
                        }
                    }
                    else if (ability == "meditate")
                    {
                        if ( target == "s1")
                       {
                           s1.Meditate();
                       }
                       else
                       {
                           Console.WriteLine("This ability can only be used to self !");
                       }
                    }
                    
                }
            }
            
            
        }
    }
}
