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

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Person newPerson)
    {
        if (ModelState.IsValid)
        {
            await _personRepo.CreateAsync(newPerson);
            // save to the database
            return RedirectToAction("Index");
        }
        return View(newPerson);
    }

    public async Task<IActionResult> Details(int id)
    {
        Person? person = await _personRepo.ReadAsync(id);
        if (person == null)
        {
            return RedirectToAction("Index");
        }
        return View(person);
    }

    public async Task<IActionResult> Edit(int id)
    {
        Person? person = await _personRepo.ReadAsync(id);
        if (person == null)
        {
            return RedirectToAction("Index");
        }
        return View(person);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Person newPerson)
    {
        if (ModelState.IsValid)
        {
            await _personRepo.UpdateAsync(newPerson.Id, newPerson);
            // save to the database
            return RedirectToAction("Index");
        }
        return View(newPerson);
    }

    public async Task<IActionResult> Delete(int id)
    {
        Person? person = await _personRepo.ReadAsync(id);
        if (person == null)
        {
            return RedirectToAction("Index");
        }
        return View(person);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _personRepo.DeleteAsync(id);
        // Repo delete
        return RedirectToAction("Index");
    }
}