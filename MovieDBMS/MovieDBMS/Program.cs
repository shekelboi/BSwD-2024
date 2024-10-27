using Database;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

public delegate void MovieDataLoadedEventHandler(object sender, EventArgs e);

internal class Program
{
    public static event MovieDataLoadedEventHandler? MoviesLoaded;

    private static void Main(string[] args)
    {
        MoviesLoaded += MovieDataLoadedEventHandler;
        Database.MovieDbContext dbContext = new Database.MovieDbContext();
        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();
        MovieRepository movieRepository = new MovieRepository();
        MovieData movieData = MovieData.Load("LargeMovieData.xml");
        movieRepository.AddRange(movieData.Movies);
        MoviesLoaded.Invoke(new Program(), new EventArgs());

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        #region 1. Simple LINQ Queries
        Console.WriteLine("1. Simple LINQ Queries");
        Console.WriteLine("Directed by Nolan:");
        var query = from m in dbContext.Movies
                    where m.Director == "Christopher Nolan"
                    select m;
        query.ToList().ForEach(m => Console.WriteLine(m.Title));
        string queryJson = JsonSerializer.Serialize(query.ToList(), options);
        File.WriteAllText("s1.json", queryJson);

        Console.WriteLine("Movies from 2010:");
        query = from m in dbContext.Movies
                where m.ReleaseYear == 2010
                select m;
        query.ToList().ForEach(m => Console.WriteLine(m.Title));
        queryJson = JsonSerializer.Serialize(query.ToList(), options);
        File.WriteAllText("s2.json", queryJson);

        Console.WriteLine("Sci-Fi movies:");
        query = from m in dbContext.Movies
                where m.Genre == "Sci-Fi"
                select m;
        query.ToList().ForEach(m => Console.WriteLine(m.Title));
        queryJson = JsonSerializer.Serialize(query.ToList(), options);
        File.WriteAllText("s3.json", queryJson);

        Console.WriteLine("Movies rated higher than 8.5:");
        query = from m in dbContext.Movies
                where m.Rating > 8.5
                select m;
        query.ToList().ForEach(m => Console.WriteLine($"{m.Title} - {m.Rating}"));
        queryJson = JsonSerializer.Serialize(query.ToList(), options);
        File.WriteAllText("s4.json", queryJson);

        Console.WriteLine("Top 5 highest rated movies:");
        query = (from m in dbContext.Movies
                 orderby m.Rating descending
                 select m).Take(5);
        query.ToList().ForEach(m => Console.WriteLine($"{m.Title} - {m.Rating}"));
        queryJson = JsonSerializer.Serialize(query.ToList(), options);
        File.WriteAllText("s5.json", queryJson);
        #endregion

        #region 2. Medium Complexity LINQ Queries
        Console.WriteLine("2. Medium Complexity LINQ Queries");
        Console.WriteLine("Movies between 2000 and 2010:");
        query = from m in dbContext.Movies
                where m.ReleaseYear >= 2000 && m.ReleaseYear <= 2010
                select m;
        query.ToList().ForEach(m => Console.WriteLine(m.Title));
        queryJson = JsonSerializer.Serialize(query.ToList(), options);
        File.WriteAllText("m1.json", queryJson);

        Console.WriteLine("Action movies rated higher than 8.0:");
        query = from m in dbContext.Movies
                where m.Genre == "Action" && m.Rating > 8.0
                select m;
        query.ToList().ForEach(m => Console.WriteLine(m.Title));
        queryJson = JsonSerializer.Serialize(query.ToList(), options);
        File.WriteAllText("m2.json", queryJson);

        Console.WriteLine("Movies sorted by release year (asc) and rating (desc):");
        query = from m in dbContext.Movies
                orderby m.ReleaseYear ascending, m.Rating descending
                select m;
        query.ToList().ForEach(m => Console.WriteLine($"{m.Title} ({m.ReleaseYear}) - {m.Rating}"));
        queryJson = JsonSerializer.Serialize(query.ToList(), options);
        File.WriteAllText("m3.json", queryJson);

        Console.WriteLine("Movies by genre:");
        var groupbyQuery = from m in dbContext.Movies
                           group m by m.Genre into g
                           select new { Genre = g.Key, Count = g.Count() };
        groupbyQuery.ToList().ForEach(m => Console.WriteLine($"{m.Genre}: {m.Count}"));
        queryJson = JsonSerializer.Serialize(groupbyQuery.ToList(), options);
        File.WriteAllText("m4.json", queryJson);

        Console.WriteLine("Top 3 movies by Quentin Tarantino:");
        query = (from m in dbContext.Movies
                 where m.Director == "Quentin Tarantino"
                 orderby m.Rating descending
                 select m).Take(3);
        query.ToList().ForEach(m => Console.WriteLine($"{m.Title}"));
        queryJson = JsonSerializer.Serialize(query.ToList(), options);
        File.WriteAllText("m5.json", queryJson);
        #endregion

        #region 3. Complex LINQ Queries
        Console.WriteLine("3. Complex LINQ Queries");

        Console.WriteLine("Genres with their average ratings:");
        var genreRatingQuery = from m in dbContext.Movies
                               group m by m.Genre into g
                               select new { Genre = g.Key, Average = g.Average(mov => mov.Rating) };
        genreRatingQuery.ToList().ForEach(m => Console.WriteLine($"{m.Genre}: {m.Average}"));
        queryJson = JsonSerializer.Serialize(genreRatingQuery.ToList(), options);
        File.WriteAllText("c1.json", queryJson);

        Console.WriteLine("Movies between 1990 and 1999 with higher rating than 8.0:");
        query = from m in dbContext.Movies
                where m.ReleaseYear >= 1990 && m.ReleaseYear <= 1999 && m.Rating > 8.0
                select m;
        query.ToList().ForEach(m => Console.WriteLine($"{m.Title} ({m.ReleaseYear}): {m.Rating}"));
        queryJson = JsonSerializer.Serialize(query.ToList(), options);
        File.WriteAllText("c2.json", queryJson);

        Console.WriteLine("Movies with King in their names with a rating above 8.5:");
        query = from m in dbContext.Movies
                where m.Title.Contains("King") && m.Rating > 8.5
                select m;
        query.ToList().ForEach(m => Console.WriteLine($"{m.Title}: {m.Rating}"));
        queryJson = JsonSerializer.Serialize(query.ToList(), options);
        File.WriteAllText("c3.json", queryJson);

        Console.WriteLine("Top 5 by genre:");
        var topFiveQuery = from m in dbContext.Movies
                           group m by m.Genre into g
                           select new { Genre = g.Key, Movies = g.OrderByDescending(mov => mov.Rating).Take(5).ToList() };
        topFiveQuery.ToList().ForEach(m => Console.WriteLine($"{m.Genre}: {string.Join(", ", m.Movies.Select(mov => mov.Title))}"));
        queryJson = JsonSerializer.Serialize(topFiveQuery.ToList(), options);
        File.WriteAllText("c4.json", queryJson);

        double averageRating = dbContext.Movies.Average(m => m.Rating);
        Console.WriteLine($"Movies by Christopher Nolan that have higher rating than average ({averageRating}):");
        query = from m in dbContext.Movies
                where m.Director == "Christopher Nolan" && m.Rating > averageRating
                select m;
        query.ToList().ForEach(m => Console.WriteLine($"{m.Title}: {m.Rating}"));
        queryJson = JsonSerializer.Serialize(query.ToList(), options);
        File.WriteAllText("c5.json", queryJson);
        #endregion
    }

    private static void MovieDataLoadedEventHandler(object sender, EventArgs e)
    {
        Console.WriteLine("Successfully loaded the data about movies.");
    }
}