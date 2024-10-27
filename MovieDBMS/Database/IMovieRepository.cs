using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public interface IMovieRepository
    {
        public bool Add(Movie movie);
        public bool AddRange(IEnumerable<Movie> movies);
    }
}
