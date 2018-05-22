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
            Console.WriteLine("Welcome to Movie Recommander !");
            bool result = MovieRecommender.ImportExcelMovieFile();
            if(result)
            {
                Console.WriteLine($"We have {MovieRecommender.MostPopularMovies2017.Count} movies in total.");
                Console.WriteLine("Your commands: a - Action, c - Comedy, r - Romance, l - List recommended movies, e - Exit program");
                MovieRecommender.ProcessUserInput();
            }
            else
            {
                Console.WriteLine("There is a problem importing movies data");
            }
        }
    }
}
