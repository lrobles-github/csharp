using System;


namespace fundementals1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            for (int i = 0; i < 256; i++)
            {
                Console.WriteLine(i);
            }
            for (int i = 0; i < 101; i++)
            {
                String strOut = "";
                int ri = rand.Next(0,100);
                // Console.WriteLine(ri);
                // Console.WriteLine(i/3 + " = " + i/3.0);
                // Console.WriteLine(i/3 == i/3.0);
                if(ri%3==0 ) {
                    strOut += "Fizz";
                }
                if(ri%5==0 ) {
                    strOut += "Buzz";
                }
                if(strOut.Length>0){
                    Console.WriteLine(ri + ": " + strOut);
                }
            }
        }
    }
}