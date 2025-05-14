using Microsoft.EntityFrameworkCore;
using MvcTherapy.Data;

namespace MvcTherapy.Models;

public static class SeedData
{
    // initializes database with some default test data when application starts
    public static void Initialize(IServiceProvider serviceProvider)
    {
        // create a new instance of EF Core DbContext (MvcTherapyContext)
        using (var context = new MvcTherapyContext(
            // use dependency injection to get the configuration options needed from Program.cs
            serviceProvider.GetRequiredService<DbContextOptions<MvcTherapyContext>>()))
        {
            // Check if the DB is already seeded
            if (context.Patient.Any())
            {
                return; // DB has data already
            }

            // Seed patients
            var sally = new Patient
            {
                Name = "Sally Smith",
                Appointment = DateTime.Parse("2025-10-12 14:30"),
                Goals = "Reduce anxiety",
                Ratings = new List<Ratings>
                {
                    new Ratings { Rating = 3, DateRecorded = DateTime.Now.AddDays(-8), Notes = "First Session" },
                    new Ratings { Rating = 8, DateRecorded = DateTime.Now.AddDays(-1), Notes = "Improved with Meditation" }
                }
            };

            var john = new Patient
            {
                Name = "John Doe",
                Appointment = DateTime.Parse("2025-06-13 09:00"),
                Goals = "Improve communication, Deal with Trauma",
                Ratings = new List<Ratings>
                {
                    new Ratings { Rating = 4, DateRecorded = DateTime.Now.AddDays(-20), Notes = "First session" },
                    new Ratings { Rating = 7, DateRecorded = DateTime.Now.AddDays(-3), Notes = "SSRIs" }
                }
            };

            var nancy = new Patient
            {
                Name = "Nancy Larson",
                Appointment = DateTime.Parse("2025-05-23 11:30"),
                Goals = "Increase self-esteem",
                Ratings = new List<Ratings>
                {
                    new Ratings { Rating = 5, DateRecorded = DateTime.Now.AddDays(-10), Notes = "Initial session" },
                    new Ratings { Rating = 3, DateRecorded = DateTime.Now.AddDays(-3), Notes = "Social Media" }
                }
            };

            var carl = new Patient
            {
                Name = "Carl Bravo",
                Appointment = DateTime.Parse("2025-06-15 16:00"),
                Goals = "Develop coping skills, Improve sleep",
                Ratings = new List<Ratings>
                {
                    new Ratings { Rating = 8, DateRecorded = DateTime.Now.AddDays(-20), Notes = "Doing good" },
                    new Ratings { Rating = 3, DateRecorded = DateTime.Now.AddDays(-8), Notes = "Difficult session" },
                    new Ratings { Rating = 10, DateRecorded = DateTime.Now.AddDays(-2), Notes = "Exercise" }
                }
            };

            // Add all four patients and their related ratings to the Patient table
            context.Patient.AddRange(sally, john, nancy, carl);
            context.SaveChanges(); // Save to get generated IDs
        }
    }
}
