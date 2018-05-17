using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movieapp
{
    class Program
    {
        static void Main(string[] args)
        {
            Movie movie1 = new Movie
            {
                MovieName = "Captain America - Civil War",
                ReleaseDate = new DateTime(2016, 4, 28),
                Rating = 7.9
            };
            movie1.ActorNames[0] = "Chris Evans";
            movie1.ActorNames[1] = "Robert Downe";

            Console.WriteLine("{0} is realease on {1:dd/MM/yyyy} with rating is {2}", movie1.MovieName, movie1.ReleaseDate, movie1.Rating);
            Console.WriteLine("Actor Names : {0}, {1}, {2}", movie1.ActorNames[0], movie1.ActorNames[1], movie1.ActorNames[2]);

            Movie movie2 = new Movie("The Avengers", new DateTime(2012, 4, 28), 8.1);
            Console.WriteLine("{0} is realease on {1:dd/MM/yyyyB} with rating is {2}", movie2.MovieName, movie2.ReleaseDate, movie2.Rating);
        }
    }
}
