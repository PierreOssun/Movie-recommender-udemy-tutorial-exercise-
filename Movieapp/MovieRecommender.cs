using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Office.Interop.Excel;

namespace Movieapp
{
    public static class MovieRecommender
    {
        public static List<Movie> MostPopularMovies2017 { get; private set; }
        private static List<Movie> myRecommendedMovies;

        public static bool ImportExcelMovieFile()
        {
            InstantiateList();

            Console.WriteLine("Grabbing movies from Excel file...");

            var result = true;
            Application oExcel = null;
            Workbook wb = null;
            Worksheet wks = null;

            try
            {
                oExcel = new Application();
                string filePath = Path.GetFullPath(@"..\..\App_Data\MovieListImport.xlsx");
                wb = oExcel.Workbooks.Open(filePath);
                wks = wb.Worksheets[1];

                var usedRange = wks.UsedRange;
                for (var r = 2; r <= usedRange.Rows.Count; r++)
                {
                    Movie coolMovie = new Movie
                    {
                        MovieName = wks.Cells[r, 1].Value.ToString(),
                        Genre = wks.Cells[r, 2].Value.ToString(),
                        IMDbRating = double.Parse(wks.Cells[r, 3].Value.ToString())
                    };
                    MostPopularMovies2017.Add(coolMovie);
                }
            }
            catch(COMException ex)
            {
                WriteToLogFile(ex.ToString());
                result = false;
            }
            catch (FormatException ex)
            {
                WriteToLogFile(ex.ToString());
                result = false;
            }
            catch (RuntimeBinderException ex)
            {
                WriteToLogFile(ex.ToString());
                result = false;
            }
            finally
            {
                if(wb != null)
                {
                    wb.Close();
                }

                if(oExcel != null)
                {
                    oExcel.Quit();
                }
                var excelProcs = Process.GetProcessesByName("EXCEL");
                foreach(var proc in excelProcs)
                {
                    proc.Kill();
                }
            }
            return result;
        }

        internal static void ProcessUserInput()
        {
            string input = null;
            Movie selectedMovie = null;
            while (input != "e")
            {
                Console.WriteLine("Your input:");
                input = Console.ReadLine();
                switch(input)
                {
                    case "a":
                        selectedMovie = MostPopularMovies2017.Where(m => m.Genre == "Action").FirstOrDefault();
                        RecommendMovie(selectedMovie, input);
                        break;
                    case "c":
                        selectedMovie = MostPopularMovies2017.Where(m => m.Genre == "Comedy").FirstOrDefault();
                        RecommendMovie(selectedMovie, input);
                        break;
                    case "r":
                        selectedMovie = MostPopularMovies2017.Where(m => m.Genre == "Romance").FirstOrDefault();
                        RecommendMovie(selectedMovie, input);
                        break;
                    case "l":
                        var movieCount = myRecommendedMovies.Count;
                        if(movieCount > 0)
                        {
                            Console.WriteLine($"You have {movieCount} movie(s):");
                            foreach(var m in myRecommendedMovies)
                            {
                                Console.WriteLine($"{m.MovieName}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("you haven't been recommended any movie yet");
                        }
                        break;
                    case "e":
                        Console.WriteLine("Thank you for using Movie Recommander 2017");
                        break;
                    default:
                        Console.WriteLine("your command is invalid.");
                        break;
                }
            }
        }

        private static void RecommendMovie(Movie selectedMovie, string input)
        {
            if(selectedMovie != null)
            {
                myRecommendedMovies.Add(selectedMovie);
                MostPopularMovies2017.Remove(selectedMovie);
                Console.WriteLine($"We recommend '{selectedMovie.MovieName}' with IMDb rating {selectedMovie.IMDbRating}");
            }
            else
            {
                Console.WriteLine("You have taken all movies already ! No one left int the list !");
            }
        }

        private static void WriteToLogFile(string exception)
        {
            var logFilePath = @"..\..\Log\log.txt";
            using (StreamWriter file = new StreamWriter(logFilePath, true))
            {
                file.WriteLine($"[EXCEPTION DETAILS]: {exception}, [DATE]: {DateTime.Now}");
            }
        }

        private static void InstantiateList()
        {
            MostPopularMovies2017 = new List<Movie>();
            myRecommendedMovies = new List<Movie>();
        }
    }
}
