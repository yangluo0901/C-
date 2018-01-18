namespace human
{
    public class Spider:Enemy
    {
        public Spider(string name):base()
        {
            this.name = name;
        }
        public Spider(string name, int intelligence, int health):base()
        {
            this.name = name;
            this.intelligence = intelligence;
            this.health = health;
        }
    }
}