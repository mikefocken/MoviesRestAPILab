using Microsoft.EntityFrameworkCore;
using MoviesWebAPi.Models;

namespace MoviesWebAPi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
        } 




    }
}
