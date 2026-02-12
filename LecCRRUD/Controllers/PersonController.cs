using Microsoft.AspNetCore.Mvc;
using LecCRRUD.Models.Entities;
using LecCRRUD.Services;

namespace LecCRRUD.Controllers;

public class PersonController : Controller 
{
    public readonly IPersonRepository _personRepo;

    public PersonController(IPersonRepository personRepo) 
    {
        _personRepo = personRepo;
    }

    public async Task<IActionResult> Index() // person/index
    {
        var peopleModel = await _personRepo.ReadAllAsync();
        return View(peopleModel);
    }
}