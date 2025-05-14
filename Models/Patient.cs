using System.ComponentModel.DataAnnotations;

namespace MvcTherapy.Models; // Namespaces help organize code into logical groups and avoid naming conflicts in larger projects

public class Patient
{
    public int Id { get; set; } // primary key. get, set means property can be read from or assigned to 
    public string? Name { get; set; }
    
    [Display(Name = "Next Appointment")]
    public DateTime Appointment { get; set; }

    public string? Goals { get; set; }

    [Display(Name = "Current Rating")]

    // A property that holds a list of Rating objects for the patient, initializes it as an empty list to avoid null issues
    public List<Ratings> Ratings { get; set; } = new();

}