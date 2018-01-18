namespace human
{
    public class Enemy
    {
        public string name;
        public int health;
        public int intelligence;
        public Enemy()
        {
            health = 300;
            intelligence = 3;
        }
        public void Auto_attack(Human A)
        {
            A.health -= 5 * intelligence;
        }
    }
}