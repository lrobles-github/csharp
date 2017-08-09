namespace animalKindgdom
{
    public class Bird : Animal
    {
        public Bird(int nl, string n, double w) : base(nl, n, w)
        {
            numLegs = 2;
        }

        new public string move() 
        {
            string movedString = "I bird just moved";
            return movedString;
        } 

        public void speak()
        {
            System.Console.WriteLine("chirp!");
        }

    }
}