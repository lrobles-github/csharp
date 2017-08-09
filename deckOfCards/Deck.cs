using System;
using System.Collections.Generic;
using System.Linq;


namespace deckOfCards
{
// Next, create a class called "Deck"
// Give the Deck class a property called "cards" which is a list of Card objects
// When initializing the deck make sure that it has a list of 52 unique cards as its "cards" property
// Give the Deck a deal method that selects the "top-most" card, removes it from the list of cards, and returns the Card
// Give the Deck a reset method that resets the cards property to the contain the original 52 cards
// Give the Deck a shuffle method that randomly reorders the deck's cards
    
    public class Deck
    {
        List<Card> cards = new List<Card>();
        
        string[] cardSuits = {"Clubs", "Spades", "Hearts", "Diamonds"};
        string[] cardVals = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};

        public Deck()
        {
            for (int s = 0; s < cardSuits.Length; s++)
            {
                for (int v = 0; v < cardVals.Length; v++)
                {
                    Card card = new Card(cardSuits[s], cardVals[v], v+1);
                    cards.Add(card);
                    System.Console.WriteLine("Deck: {0} of {1}", cardVals[v],cardSuits[s]);
                }
            }
        }

        public Card deal()
        {
            Card dealCard = cards[0];
            cards.RemoveAt(0);
            System.Console.WriteLine("Deck deal: {0} of {1}", dealCard.stringVal,dealCard.suit);
            return dealCard;
        }

        public void reset(Deck d)
        {
            d.cards.Clear();
            List<Card> cards = new List<Card>();

            for (int s = 0; s < cardSuits.Length; s++)
            {
                for (int v = 0; v < cardVals.Length; v++)
                {
                    Card card = new Card(cardSuits[s], cardVals[v], v+1);
                    cards.Add(card);
                    System.Console.WriteLine("Reset Deck: {0} of {1}", cardVals[v],cardSuits[s]);
                }
            }        
        }

        public void shuffle()
        {
            Random rand = new Random();
            for (int i = 0; i < cards.Count; i++)
            {
                int randNum = rand.Next(i, cards.Count);
                Card temp = cards[i];
                cards[i] = cards[randNum];
                cards[randNum] = temp;
            }

            foreach (Card c in cards)
            {
                System.Console.WriteLine("Shuffle Deck: {0} of {1}", c.stringVal,c.suit);            
            }
            
        }
    }
}