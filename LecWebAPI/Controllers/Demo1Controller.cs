using Microsoft.AspNetCore.Mvc;
namespace LecWebAPI.Controllers;

[Route("lec/demoone")]
public class Demo1Controller : Controller 
{
    [HttpGet]
    public IActionResult Index(){
        return Content("A plain GET endpoint.");
    }

    [HttpGet("{id}")]
    public IActionResult InforWithId(string id) 
    {
        return Content($"A GET endpoint with parameter id {id}.");
    }

    [HttpGet("intdata/{id:int}")]
    public IActionResult InfoWithIntId(int id)
    {
        return Content($"A GET endpoint with 3 segments and a parameter that must be in int: {id}");    
    }
}