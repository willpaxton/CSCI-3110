using Microsoft.AspNetCore.Mvc;

namespace Lab5WPBookAuthorApp.Controllers;

public class BookController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}