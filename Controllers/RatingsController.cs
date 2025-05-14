using Microsoft.AspNetCore.Mvc;
using MvcTherapy.Data;
using MvcTherapy.Models;

namespace MvcTherapy.Controllers // Namespaces help organize code into logical groups and avoid naming conflicts in larger projects
{
    public class RatingsController : Controller
    {
        private readonly MvcTherapyContext _context;

        // dependency injection to automatically provide an instance of Entity Framework database context when controller is created
        public RatingsController(MvcTherapyContext context)
        {
            _context = context; // storing the injected context in the _context field to use it in controller actions to access the database
        }



        [HttpPost] // method is invoked when a form sends data to the server via a POST request
        [ValidateAntiForgeryToken] // prevent Cross-Site Request Forgery attacks
        // accessible publicly (called from outside class), runs asyncronously, bind data from the HTTP request body to the rating parameter
        // handles the creation of a new Ratings object
        public async Task<IActionResult> Create([FromBody] Ratings rating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            rating.DateRecorded = DateTime.Now; // set the date recorded to current date automatically
            _context.Ratings.Add(rating); // add rating object to context
            await _context.SaveChangesAsync(); // save changes to database

            // send JSON data to page so that AJAX (js) can update graph dynamically 
            return Json(new
            {
                rating = rating.Rating,
                date = rating.DateRecorded.ToString("MMM dd, yyyy"),
                notes = rating.Notes
            });
        }
    }
}