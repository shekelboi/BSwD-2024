using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Database
{
    [XmlRoot("MovieData")]
    public class MovieData
    {
        [XmlElement("Movie")]
        public List<Movie> Movies { get; set; }

        public MovieData()
        {
            
        }

        public static MovieData Load(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(MovieData));
            using (StreamReader sr = new StreamReader(path))
            {
                return (MovieData) xmlSerializer.Deserialize(sr);
            }
        }
    }
}
