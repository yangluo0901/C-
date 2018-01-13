using System;

namespace Cards
{   
    class Cards
    {
        public string stringVal; //hold the value of the card ex. (Ace, 2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King)
        public string suit;     //hold the suit of the card (Clubs, Spades, Hearts, Diamonds)
        public int val;         //hold the numerical value of the card 1-13 as integers
    }
    class Deck
    {
        public static List<object> cards;
        public static List<object> Deck()  // initialize deck;
        {   
            List<object> cards_origin =  new List<object>();
            for ( int i = 0; i < 52; i++)
            {
                cards_origin.Add()
            }
            List<object> cards = cards_origin;
            return cards_origin;
            
        }
        public object TopMost()
        {   
            cards.RemoveAt(0);
            object topmost = list[0];
            return topmost;
        }
        public void Reset(){
            cards = cards_origin;
        }
        public void Shuffle()
        {
            Random rand =  new Random();
            for ( int i = 0; i < cards.Length -1; i++)
            {
                int index =  rand.Next(i+1, cards.Length-1);
                string temp  =  cards[index];
                cards[index] = cards[i];
                cards[i] = temp;
            }
        }
    }
    class Player{
        public string name;
        public List<object> cards;
        public object Draw()
        {

        }
        public object Discard(int index)
        {
            cards.RemoveAt(index);
            return cards[index];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
