using System;

namespace deckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck myDeck = new Deck();
            myDeck.shuffle();
            Player luis = new Player();
            luis.name = "Luis";
            luis.draw(myDeck);
            luis.draw(myDeck);        
            luis.discard(0);    
        }
    }
}





