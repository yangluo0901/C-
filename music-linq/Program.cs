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
            Artist list = Artists.Where(str=> str.Hometown == "Mount Vernon").Single();
            Console.WriteLine($"The artist {list.ArtistName} from Mt Vernon is {list.Age} years old");  
            //Who is the youngest artist in our collection of artists?
            var list = (from entry in Artists
                        orderby entry.Age ascending
                        select new {entry.ArtistName,entry.Age}).ToList();
                        Console.WriteLine(list[0].Age+list[0].ArtistName);
            Artist Youngest = Artists.OrderBy(artist => artist.Age).First();
            Console.WriteLine($"The Youngest artist is {Youngest.ArtistName}");
            
            //Display all artists with 'William' somewhere in their real name
            IEnumerable<Artist> artists = Artists.Where(str=> str.RealName.Contains("William"));
            foreach( var entry in artists)
            {
                Console.WriteLine(entry.RealName);
            }
            //Display the 3 oldest artist from Atlanta
            List<Artist> Atlanta = Artists.Where(str=> str.Hometown == "Atlanta").OrderByDescending(str=> str.Age).ToList();
            for ( int i = 0; i<3; i++)
            {
                Console.WriteLine(Atlanta[i].RealName+" age is "+Atlanta[i].Age);
            }
            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            var group1 = Groups.Join(Artists,
                                            group=> group.Id,
                                            artist=> artist.GroupId,
                                            (group,artist)=>new { group.GroupName, artist.Hometown} )
                                            .Where(entry=> entry.Hometown != "New York City")
                                            .Distinct();
                                           
                                            
            
            // foreach ( var entry in group1)
            // {
            //     Console.WriteLine(entry.GroupName);
            // }
            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            var artists= Artists.Join(Groups,
                         artist=> artist.GroupId,
                         group=> group.Id,
                         (artist,group) => new{artist.RealName,group.GroupName})
                         .Where(entry=> entry.GroupName=="Wu-Tang Clan");
            foreach ( var entry in artists)
            {
                Console.WriteLine(entry);
            }            
        }
    }
}
