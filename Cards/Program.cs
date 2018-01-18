using System;
using System.Collections.Generic;
namespace Cards
{   
    public class Card
    {
        public string stringVal //hold the value of the card ex. (Ace, 2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King)
        {
            get
            {
                if(val > 1 && val < 11)
                {
                    return val.ToString();
                }
                else if ( val == 1)
                {
                    return "Ace";
                }
                else if (val == 11)
                {
                    return "Jack";
                }
                else if (val == 12)
                {
                    return "Queen";
                }
                else if ( val == 13)
                {
                    return "King";
                }
                else
                {
                    return "false";
                }
            }
        }
        public string suit;     //hold the suit of the card (Clubs, Spades, Hearts, Diamonds)
        public int val;         //hold the numerical value of the card 1-13 as integers
        
        public Card(string suit, int val)
        {
            this.suit =  suit;
            this.val = val;
        }
    }
    public class Deck
    {
        private List<Card> cards;
        public Deck()  // initialize deck;
        {   
             Reset();
        }
        public Deck Reset()
        {
            cards =  new List<Card>();
             string[] suits =  new string []{"clubs","spades","hearts","diamonds"};
             foreach(string suit in suits)
             {
                 for (int i = 1; i < 14; i++)
                 {
                     cards.Add(new Card(suit, i));
                 }
             }
            return this;
        }
        public Card Draw()
        {
            if (cards.Count > 1)
            {
                Card temp = cards[0];
                cards.RemoveAt(0);
                return temp;
            }
            return null;
        }
        public Card TopMost()
        {   
            Card topmost = cards[0];
            cards.RemoveAt(0);
            return topmost;
        }
       
        public Deck Shuffle()
        {
            Random rand =  new Random();
            for ( int i = 0; i < cards.Count -1; i++)
            {
                int index =  rand.Next(i+1, cards.Count-1);
                Card temp  =  cards[index]; 
                cards[index] = cards[i];
                cards[i] = temp;
            }
            return this;
        }
    }
    class Player{
        public string name;
        public List<Card> handcards;
        public Player (string name)
        {
            this.name = name;
            handcards = new List<Card>();
        }
        public void Draw(Deck deck)
        {
            handcards.Add(deck.Draw());
        }
        public Card Discard(int index)
        {   
            Card temp =  handcards[index];
            handcards.RemoveAt(index);
            return temp;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck1 = new Deck();
            Player player1 = new Player("tester");
            Console.WriteLine(deck1);
        }
    }
}
