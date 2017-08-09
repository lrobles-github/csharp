using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

//There is only one artist in this collection from Mount Vernon, what is their name and age?
            System.Console.WriteLine("=================================");

            var mtvernonQuery = from a in Artists
                where a.Hometown == "Mount Vernon"
                select new {a.ArtistName, a.Age};
            
            foreach (var item in mtvernonQuery)
            {
                System.Console.WriteLine("From Mt Vernon: " + item.ArtistName + " " + item.Age);
            }

            var mtVernonArtist = mtvernonQuery.Take(1);

            System.Console.WriteLine(mtVernonArtist.First().ArtistName);


//Who is the youngest artist in our collection of artists?
            System.Console.WriteLine("=================================");

            var youngestQuery = 
                from a in Artists
                orderby a.Age
                select new {a.ArtistName, a.Age};

            var y = youngestQuery.Take(1);
            
            // foreach (var a in youngestQuery)
            // {
            //     System.Console.WriteLine(a.ArtistName + " " + a.Age);
            // }

            System.Console.WriteLine("With var: " + y.First().ArtistName + " " + y.First().Age);

            IEnumerable<Artist> youngestQuerywithIEnum = 
                from a in Artists
                orderby a.Age
                select a;

            var yo = youngestQuerywithIEnum.Take(1);

            System.Console.WriteLine("with IEnum: " + yo.First().ArtistName + " " + yo.First().Age);


//Display all artists with 'William' somewhere in their real name
            System.Console.WriteLine("=================================");

            IEnumerable<Artist> william = 
                from a in Artists
                where a.RealName.Contains("William")
                select a;

            System.Console.WriteLine("With Ienum:");
            foreach (var a in william)
            {
                System.Console.WriteLine(a.ArtistName + " " + a.RealName);
            }

            System.Console.WriteLine("With var:");
            var williamVar = 
                from a in Artists
                where a.RealName.Contains("William")
                select new {a.ArtistName, a.RealName};

            foreach (var a in williamVar)
            {
                System.Console.WriteLine(a.ArtistName + " " + a.RealName);
            }

//Display the 3 oldest artists from Atlanta
            System.Console.WriteLine("=================================");

            IEnumerable<Artist> oldest = 
                from a in Artists
                where a.Hometown is "Atlanta"
                orderby a.Age descending
                select a;

            var threeOldest = oldest.Take(3);

            foreach (var a in threeOldest)
            {
                System.Console.WriteLine(a.ArtistName + " " + a.Age);
            }
            
            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            System.Console.WriteLine("=================================");

            // from Solutions
            List<string> NonNewYorkGroups = Artists
                                .Join(Groups, artist => artist.GroupId, group => group.Id, (artist, group) => { artist.Group = group; return artist;})
                                .Where(artist => (artist.Hometown != "New York City" && artist.Group != null))
                                .Select(artist => artist.Group.GroupName)
                                .Distinct()
                                .ToList();
            Console.WriteLine("All groups with members not from New York City:");
            foreach(var group in NonNewYorkGroups){
                Console.WriteLine(group);
            }



            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            // System.Console.WriteLine("=================================");

            // var wutang = 
            //     from a in Artists
            //     where a.GroupId is 1
            //     join g in Groups on a.GroupId equals g.Id into matches
            //     select matches;

            // foreach (var a in wutang)
            // {
            //     System.Console.WriteLine(a.);
            // }

            // List<string> wutangQuery = Artists 
            //     .Join(Groups,
            //          artist => artist.GroupId,
            //          group => group.Id,
            //          (artist, group) => { artist.Group = group; return artist;})
            //     .Where(group => group.Id)
            //     .Select()
            //     .ToList()
            
            // From solutions...
            Group WuTang = Groups.Where(group => group.GroupName == "Wu-Tang Clan")
                                    .GroupJoin(Artists, 
                                        group => group.Id,
                                        artist => artist.GroupId,
                                        (group, artists) => { group.Members = artists.ToList(); return group;})
                                    .Single();
            Console.WriteLine("List of Artist in the Wu-Tang Clan:");
            foreach(var artist in WuTang.Members){
                Console.WriteLine(artist.ArtistName);
            }
                    

        }
    }
}
