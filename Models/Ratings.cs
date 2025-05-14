
namespace MvcTherapy.Models;

// Keeping the models separate ensures code is modular, each model handles only the data it's responsible for
// Proper one-to-many relationship between Patient and RatingEntries
// Easy to query, add, and display ratings over time for the chart
// clean database structure (BUG)
public class Ratings
{
    public int Id { get; set; }

    // foreign key property, tells EF Core that this rating belongs to a specific Patient.
    // the column in the Ratings table that stores the related patient's ID.
    public int PatientId { get; set; }

    // navigation property that creates a relationship between this Ratings object and the Patient it belongs to.
    // ? means the Patient can be null, which allows EF Core to lazy-load or explicitly load related data.
    // use .Include(r => r.Patient) in a query to populate this property
    public Patient? Patient { get; set; }

    public int Rating { get; set; }

    // sets the default value to the current date and time when a new Ratings object is created
    public DateTime DateRecorded { get; set; } = DateTime.Now;

    // extra comments or observations related to the rating
    public string? Notes { get; set; }
}
