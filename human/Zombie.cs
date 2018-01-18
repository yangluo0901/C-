namespace human
{
    public class Zombie:Enemy
    {
        public Zombie(string name):base()
        {
            this.name = name;
        }
        public Zombie(string name, int intelligence, int health):base()
        {
            this.name = name;
            this.intelligence = intelligence;
            this.health = health;
        }
    }
}