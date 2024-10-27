using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Database
{
    [Table("movie")]
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Director { get; set; }
        public int ReleaseYear { get; set; }
        [MaxLength(50)]
        public string Genre { get; set; }
        [Column(TypeName = "decimal(2, 1)")]
        public double Rating { get; set; }

        public Movie(int id, string title, string director, int releaseYear, string genre, double rating)
        {
            Id = id;
            Title = title;
            Director = director;
            ReleaseYear = releaseYear;
            Genre = genre;
            Rating = rating;
        }

        public Movie(XElement movieElement)
        {
            Id = int.Parse(movieElement.Element("Id").Value);
            Title = movieElement.Element("Title").Value;
            Director = movieElement.Element("Director").Value;
            ReleaseYear = int.Parse(movieElement.Element("ReleaseYear").Value);
            Genre = movieElement.Element("Genre").Value;
            Rating = Convert.ToDouble(movieElement.Element("Rating").Value);
        }
        public static List<Movie> ReadFromXml(string path)
        {
            XDocument doc = XDocument.Load(path);
            List<XElement> movies = doc.Root.Elements("Movie").ToList();
            //List<XElement> movies = doc.Root.Elements("Movie").ToList();

            return movies.Select(m => new Movie(m)).ToList();
        }
    }
}
