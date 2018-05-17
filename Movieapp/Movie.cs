﻿using System;
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

        public Movie()
        {

        }

        public Movie(string movieName, DateTime realeaseDate, double rating)
        {
            MovieName = movieName;
            ReleaseDate = realeaseDate;
            Rating = rating;
        }
    }
}
