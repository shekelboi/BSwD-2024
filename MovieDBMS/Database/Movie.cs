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

        public Movie()
        {
            
        }

        public Movie(int id, string title, string director, int releaseYear, string genre, double rating)
        {
            Id = id;
            Title = title;
            Director = director;
            ReleaseYear = releaseYear;
            Genre = genre;
            Rating = rating;
        }
    }
}
