using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class MovieRepository : IMovieRepository
    {
        MovieDbContext ctx;
        public MovieRepository()
        {
            ctx = new MovieDbContext();
        }

        public bool Add(Movie movie)
        {
            ctx.Movies.Add(movie);
            try
            {
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
                return false;
            }
            return true;
        }

        public bool AddRange(IEnumerable<Movie> movies)
        {
            ctx.Movies.AddRange(movies);
            try
            {
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
            return true;
        }
    }
}
