using LecWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using LecWebAPI.Models.Entities;

namespace LecWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetController  : ControllerBase
{
    private readonly IPetRepository _petRepo;

    public PetController(IPetRepository petRepo) 
    {
        _petRepo = petRepo;
    }

    // api/pet/all
    [HttpGet("all")]
    public async Task<IActionResult> Get() 
    {
        return Ok(await _petRepo.ReadAllAsync());
    }

    // POST api/pet/create
    [HttpPost("create")]
    public async Task<IActionResult> Post([FromForm]Pet pet)
    {
        await _petRepo.CreateAsync(pet);
        return CreatedAtAction("Get", new  { id = pet.Id}, pet);
    }

    // GET api/pet/one/{id}
    [HttpGet("one/{id}")]
    public async Task<IActionResult> Get(int id) 
    {
        var pet = await _petRepo.ReadAsync(id);
        if(pet == null)
        {
            return NotFound();
        }
        return Ok(pet);
    }

    // PUT api/pet/update
    [HttpPut("update")]
    public async Task<IActionResult> Put([FromForm] Pet pet)
    {
        await _petRepo.UpdateAsync(pet.Id, pet);
        return NoContent(); // 204 as per HTTP specification
    }

    // DELETE api/pet/delete/{id}
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _petRepo.DeleteAsync(id);
        return NoContent(); // 204 as per HTTP specification
    }

}