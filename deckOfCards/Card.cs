namespace deckOfCards
{
// Create a class called "Card"

// Give the Card class a property "stringVal" which will hold the value of the card ex. (Ace, 2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King). This "val" should be a String
// Give the Card a property "suit" which will hold the suit of the card (Clubs, Spades, Hearts, Diamonds)
// Give the Card a property "val" which will hold the numerical value of the card 1-13 as integers

    public class Card 
    {
        public string stringVal;
    
        public string suit;
    
        public int value;

        public Card(string s, string v, int val)
        {
            suit = s;
            stringVal = v;
            value = val;
        }
    }

}