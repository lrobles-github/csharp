using System;
using System.Collections.Generic;
using System.Linq;

namespace puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomArray();
            tossMultCoins(3);
            Names();
        }

        public static void RandomArray() 
        {
            Random rand = new Random();
            int[] arr = new int[10];
            
            for (int i=0; i < arr.Length; i++) {
                int num = rand.Next(5, 26);
                arr[i] = num;

            }
                    
            Console.WriteLine("The total is {0}", arr.Sum());
            Console.WriteLine("The maximum number is {0}", arr.Max());
            Console.WriteLine("The minimum number is {0}", arr.Min());
       
        }

        public static string coinToss(Random rand) 
        {
            System.Console.WriteLine("Tossing a coin...");
            if (rand.Next(0,2) == 1) 
            {
                System.Console.WriteLine("heads");
                return "heads";
            }
            else 
            {
                System.Console.WriteLine("tails");
                return "tails";
            }

        }

        public static double tossMultCoins(int num)
        {
            int headsCt = 0;
            for (int i = 1; i < num; i++) 
            {
                if (coinToss(new Random()) == "heads") 
                {
                    headsCt++;
                }
            }
            Double x = (double)headsCt/(double)num;
            System.Console.WriteLine(x);
            return x;
        }

        public static string[] Names()
        {
            string[] names = {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            Random rand = new Random();

            for(int i = 0; i < names.Length - 1; i++)
            {
                int randNum = rand.Next(i + 1, names.Length - 1);
                string temp = names[i];
                names[i] = names[randNum];
                names[randNum] = temp;
                System.Console.WriteLine(names[i]);
            }

            Console.WriteLine(names[names.Length - 1]);
            List<string> myList = new List<string>();
           
            foreach (String n in names) 
            {
                if (n.Length > 5) 
                {
                    myList.Add(n);
                    System.Console.WriteLine("added {0}", n);
                }
            }

            return myList.ToArray();

        }
    }

}