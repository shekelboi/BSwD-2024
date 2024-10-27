using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Actual SQL server
            optionsBuilder.UseSqlServer(@"Server = localhost; Database = moviedb; Trusted_Connection = True; TrustServerCertificate = True;");

            //// LocalDB
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=moviedb;Integrated Security=True");
        }
    }
}
