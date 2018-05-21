using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movieapp
{
    internal class Movie
    {
        public string MovieName { get; set; }

        public DateTime ReleaseDate { get; set; }

        public double Rating { get; set; }

        public List<string> ActorNames { get; private set; }

        public Movie()
        {
            ActorNames = new List<string>();
        }

        public Movie(string movieName, DateTime realeaseDate, double rating)
        {
            MovieName = movieName;
            ReleaseDate = realeaseDate;
            Rating = rating;
            ActorNames = new List<string>();
        }

        public void AddActor(string actorName)
        {
            ActorNames.Add(actorName);
        }

        public void AddActor(List<string> actorNames)
        {
            ActorNames.AddRange(actorNames);
        }

        public int CountActors()
        {
            return ActorNames.Count;
        }
    }
}
