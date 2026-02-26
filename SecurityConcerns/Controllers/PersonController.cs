using Microsoft.AspNetCore.Mvc;
using SecurityConcerns.Models;
using SecurityConcerns.Controllers;
using SecurityConcerns.Models.ViewModels;

namespace SecurityConcerns.Controllers;

public class PersonController : Controller
{
    // GET /person/create
    public IActionResult Create()
    {
        return View();
    }

    public IActionResult CreateVM()
    {
        return View();
    }   
    
    public IActionResult CreateVM(CreatePersonVM personVM)
    {
        Person person = personVM.GetPersonInstance();
        return Json(person);
    }

    [HttpPost, ValidateAntiForgeryToken]
    // or [ValidateAntiForgeryToken]
    public IActionResult Create(Person newPerson)
    {
        return Json(newPerson);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult CreateWithBind(
        [Bind("FirstName,LastName,DateOfBirth")]Person person)
    {
        return Json(person);
    }

    public IActionResult CreatePerson()
    {
        return View();
    }

    public IActionResult Index()
    {
        return Content("Pretend this is the index :)");
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult CreatePerson(PersonVM personVM)
    {
        if(personVM.DateOfBirth > DateTime.Now) 
        {
            ModelState.AddModelError("", "Invalid Date of Birth!");
            ModelState.AddModelError("DateOfBirth", "The date of birth cannot be in the future.");
        }

        if(ModelState.IsValid)
        {
            // Not needed in this demo
            return RedirectToAction("Index");
        }
        return View(personVM);
    }
}