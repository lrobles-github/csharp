using DbConnection;
using System;
using System.Collections.Generic;
using System.Linq;


namespace test
{
    class Program
    {
        static void Main(string[] args) 
        {
            readFrom();

            System.Console.WriteLine("Enter user's id to edit his/her favorite number:");
            int userID = Int32.Parse(Console.ReadLine());
            System.Console.WriteLine("Want to change it to what number:");
            int favNumber = Int32.Parse(Console.ReadLine());
            writeTo(userID, favNumber);

            System.Console.WriteLine("Select user's id to delete that entry:");
            int toDelete = Int32.Parse(Console.ReadLine());
            delete(toDelete);

        }

        static void readFrom()
        {
            List<Dictionary<string, object>> users = DbConnector.Query("SELECT * FROM users");   
            
            foreach (var cell in users)
            {
                System.Console.WriteLine(cell["id"] + " " + cell["FirstName"] + " " + cell["LastName"] + " " + cell["FavoriteNumber"]);
            }
        }

        static void writeTo(int id, int newNumber)
        {
            DbConnector.Execute("UPDATE users SET FavoriteNumber=" + newNumber + " WHERE id=" + id + "");
        }

        static void delete(int id)
        {
            DbConnector.Execute("DELETE FROM users WHERE id =" + id + "");
        }
    }
}