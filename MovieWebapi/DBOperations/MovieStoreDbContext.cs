using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace MovieWebapi.DBOperations 
{
    public class MovieStoreDbContext : DbContext 
    {
        public MovieStoreDbContext(DbContextOptions <MovieStoreDbContext> options) : base(options) {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}