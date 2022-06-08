using Microsoft.EntityFrameworkCore;
using ScrapySharp.Console.Data.Model;

namespace ScrapySharp.Console.Data
{
    internal class TripAdvisorDBContext : DbContext
    {
        string _connectionString = "data source=SHARJEEL-LAPTOP\\SQLEXPRESS;initial catalog=TripAdvisor;Integrated Security=SSPI;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString, option => option.EnableRetryOnFailure());
        }

        public DbSet<Location>? Location { get; set; }
        public DbSet<LocationComment>? LocationComment { get; set; }
    }
}
