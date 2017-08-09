namespace animalKindgdom
{
    public class Dog : Animal
    {
        public Dog(int nl, string n, double w) : base(nl, n, w)
        {
            numLegs = 4;
        }

        new public string move() 
        {
            string movedString = "I dog just moved";
            return movedString;
        } 

        public void speak()
        {
            System.Console.WriteLine("woof!");
        }
    }
}