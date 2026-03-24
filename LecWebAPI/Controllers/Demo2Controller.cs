using Microsoft.AspNetCore.Mvc;

namespace LecWebAPI.Controllers;

[Route("[controller]/[action]")]
public class Demo2Controller : Controller 
{
    [HttpGet]
    public IActionResult Index() 
    {
        return Content("Another simple GET endpoint");
    }

    [HttpGet("{id}")]
    public IActionResult Details(int id) 
    {
        return Content($"Details endpoint of {id}");
    }
}