using System.Threading.Tasks;
using MovieNews.Data;

namespace MovieNews.Console
{
    class Program
    {
        static async Task Demo()
        {
            var info = await Movies.GetMovieInfo("The Intern");
            if (info.HasMovie)
            {
                System.Console.WriteLine(
                    $"Name : {info.Movie.Movie.Title}\n" +
                    $"Poster : {info.Movie.Details.Poster}"
                );
            }
            System.Console.ReadLine();
        }

        static void Main(string[] args)
        {
            var demo = Demo();
            System.Console.WriteLine("downloading...");
            demo.Wait();
        }
    }
}
