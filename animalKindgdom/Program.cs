using System;

namespace animalKindgdom
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal pete = new Animal(4, "pete", 50);
            Dog billy = new Dog(1, "billy", 30);
            Bird chippy = new Bird(1, "chippy", 4);
            System.Console.WriteLine(pete.move());
            System.Console.WriteLine(billy.numLegs);
            chippy.speak();
            billy.speak();
        }
    }
}
