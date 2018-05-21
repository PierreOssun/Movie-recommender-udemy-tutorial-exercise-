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
            try
            {
                var movie1 = new Movie
                {
                    MovieName = "Captain America - Civil War",
                    ReleaseDate = new DateTime(2016, 4, 28),
                    Rating = 7.9
                };
                movie1.AddActor("Chris Evans");
                movie1.AddActor("Jennifer Lawrence");
                movie1.AddActor("Cilian Murphy");


                //movie1.ActorNames.ForEach(name => Console.WriteLine(name));
                //Console.WriteLine(movie1.CountActors());
                Console.WriteLine(movie1.GetType());
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("movie1's ActorNames not instantiated");
            }

            Movie movie2 = new Movie("The Avengers", new DateTime(2012, 4, 28), 8.1);
            List<string> actorNamesList = new List<string> { "La Chteu", "Le toutoune", "Francois" };
            movie2.AddActor(actorNamesList);
            movie2.ActorNames.ForEach(name => Console.WriteLine(name));
            Console.WriteLine(movie2.CountActors());
            string[] ActorNames = new string[] { "lala", "lilili", "lololo" };

            foreach (var d in ActorNames)
            {
                Console.WriteLine(d);
            }

        }
    }
}
