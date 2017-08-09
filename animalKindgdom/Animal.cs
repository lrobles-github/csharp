namespace animalKindgdom
{
    public class Animal
        {
            public int numLegs;
            public string name;
            public double weight;

            public Animal(int nl, string n, double w)
            {
                numLegs = nl;
                name = n;
                weight = w;
            }

            public string move()
            {
                string movedString = "I just moved";
                return movedString;
            }
        }

}