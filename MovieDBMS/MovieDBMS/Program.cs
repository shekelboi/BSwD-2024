using Database;
using System.ComponentModel.Design.Serialization;
using System.Xml.Linq;
internal class Program
{
    private static void Main(string[] args)
    {
        Database.MovieDbContext dbContext = new Database.MovieDbContext();
        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();
        MovieRepository movieRepository = new MovieRepository();
        movieRepository.AddRange(Movie.ReadFromXml("LargeMovieData.xml"));

        Console.WriteLine("Directed by Nolan:");
        var query = from m in dbContext.Movies
                    where m.Director == "Christopher Nolan"
                    select m;
        query.ToList().ForEach(m => Console.WriteLine(m.Title));

        Console.WriteLine("Action movies rated higher than 8.0:");
        query = from m in dbContext.Movies
                where m.Genre == "Action" && m.Rating > 8.0
                select m;
        query.ToList().ForEach(m => Console.WriteLine(m.Title));

        Console.WriteLine("Movies sorted by release year (asc) and rating (desc):");
        query = from m in dbContext.Movies
                orderby m.ReleaseYear ascending, m.Rating descending
                select m;
        query.ToList().ForEach(m => Console.WriteLine($"{m.Title} ({m.ReleaseYear}) - {m.Rating}"));

        Console.WriteLine("Movies rated higher than 8.5:");
        query = from m in dbContext.Movies
                where m.Rating > 8.5
                select m;
        query.ToList().ForEach(m => Console.WriteLine($"{m.Title} - {m.Rating}"));

        Console.WriteLine("Top 5 highest rated mobies:");
        query = (from m in dbContext.Movies
                 orderby m.Rating descending
                 select m).Take(5);
        query.ToList().ForEach(m => Console.WriteLine($"{m.Title} - {m.Rating}"));

    }
}