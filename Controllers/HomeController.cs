using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcTherapy.Models;

namespace MvcTherapy.Controllers; // Namespaces help organize code into logical groups and avoid naming conflicts in larger projects

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    // Caching is disabled for the error page using the [ResponseCache] attribute to ensure the page is never cached
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // If error occurs new ErrorViewModel is created, containing a RequestId that can be used to track the error
    //The Error view is rendered, and the RequestId is passed to it, which can be displayed on the error page
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
