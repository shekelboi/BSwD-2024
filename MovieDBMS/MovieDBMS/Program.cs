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

        #region 1. Simple LINQ Queries
        Console.WriteLine("1. Simple LINQ Queries");
        Console.WriteLine("Directed by Nolan:");
        var query = from m in dbContext.Movies
                    where m.Director == "Christopher Nolan"
                    select m;
        query.ToList().ForEach(m => Console.WriteLine(m.Title));

        Console.WriteLine("Movies from 2010:");
        query = from m in dbContext.Movies
                where m.ReleaseYear == 2010
                select m;
        query.ToList().ForEach(m => Console.WriteLine(m.Title));

        Console.WriteLine("Sci-Fi movies:");
        query = from m in dbContext.Movies
                where m.Genre == "Sci-Fi"
                select m;
        query.ToList().ForEach(m => Console.WriteLine(m.Title));

        Console.WriteLine("Movies rated higher than 8.5:");
        query = from m in dbContext.Movies
                where m.Rating > 8.5
                select m;
        query.ToList().ForEach(m => Console.WriteLine($"{m.Title} - {m.Rating}"));

        Console.WriteLine("Top 5 highest rated movies:");
        query = (from m in dbContext.Movies
                 orderby m.Rating descending
                 select m).Take(5);
        query.ToList().ForEach(m => Console.WriteLine($"{m.Title} - {m.Rating}"));
        #endregion

        #region 2. Medium Complexity LINQ Queries
        Console.WriteLine("2. Medium Complexity LINQ Queries");
        Console.WriteLine("Movies between 2000 and 2010:");
        query = from m in dbContext.Movies
                where m.ReleaseYear >= 2000 && m.ReleaseYear <= 2010
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

        Console.WriteLine("Movies by genre:");
        var groupbyQuery = from m in dbContext.Movies
                           group m by m.Genre into g
                           select new { Genre = g.Key, Count = g.Count() };
        groupbyQuery.ToList().ForEach(m => Console.WriteLine($"{m.Genre}: {m.Count}"));

        Console.WriteLine("Top 3 movies by Quentin Tarantino:");
        query = (from m in dbContext.Movies
                 where m.Director == "Quentin Tarantino"
                 orderby m.Rating descending
                 select m).Take(3);
        query.ToList().ForEach(m => Console.WriteLine($"{m.Title}"));
        #endregion

    }
}