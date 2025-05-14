using Microsoft.EntityFrameworkCore; // EF Core

namespace MvcTherapy.Data
{
    // DbContext is a core class in EF Core. It represents a session with the database, allowing you to query and save data.
    // manages the database connections and is used for interacting with the underlying database through models
    public class MvcTherapyContext : DbContext
    {
        // DbContextOptions contains configuration information for how the context will interact with the database
        // constructor allows dependency injection to provide the options, configured Program.cs
        public MvcTherapyContext (DbContextOptions<MvcTherapyContext> options)
            : base(options)
        {
        }

        // These two properties define the tables that EF Core will manage within the MvcTherapyContext
        // will map to tables in the database and allow CRUD operations on the records
        public DbSet<MvcTherapy.Models.Patient> Patient { get; set; } = default!;
        public DbSet<MvcTherapy.Models.Ratings> Ratings { get; set; }
    }
}
