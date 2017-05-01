using MovieNews.Data;

namespace MovieNews.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var info = Movies.GetMovieInfo("The Intern");
            if (info.HasMovie)
            {
                System.Console.WriteLine(
                    $"Name : {info.Movie.Movie.Title}\n"+
                    $"Poster : {info.Movie.Details.Poster}"
                    );

            }
            System.Console.ReadLine();
        }
    }
}
