using System.Collections.Generic;

namespace deckOfCards
{
// Finally, create a class called "Player"

// Give the Player class a name property
// Give the Player a hand property that is a List of type Card
// Give the Player a draw method of which draws a card from a deck, adds it to the player's hand and returns the Card
// Note this method will require reference to a deck object
// Give the Player a discard method which discards the Card at the specified index from the player's hand and returns this Card or null if the index does not exist.
    class Player
    {
        public string name;
        public List<Card> hand = new List<Card>();

        public Card draw(Deck deck)
        {
            hand.Insert(0, deck.deal());
            System.Console.WriteLine("Draw: {0} of {1}", hand[0].stringVal,hand[0].suit);
            return hand[0];
        }

        public Card discard(int index)
        {
            if (hand[index] != null)
            {
                System.Console.WriteLine("Removing {0} of {1}", hand[0].stringVal,hand[0].suit);
                Card c = hand[index];
                hand.RemoveAt(index);

                foreach (Card card in hand)
                {
                    System.Console.WriteLine("Hand: {0} of {1}", card.stringVal,card.suit);
                }

                return c;
            }
            else
            {
                return null;
            }

        }
    }
}