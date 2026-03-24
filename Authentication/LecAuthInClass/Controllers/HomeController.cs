using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LecAuthInClass.Models;
using LecAuthInClass.Services;
using Microsoft.AspNetCore.Authorization;
using LecAuthInClass.Models.Entities;


namespace LecAuthInClass.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUserRepository _userRepo;


    public HomeController(IUserRepository userRepo, ILogger<HomeController> logger)
    {
        _logger = logger;
        _userRepo = userRepo;
    }


    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetUserName()
    {
        if (User.Identity != null && User.Identity.IsAuthenticated)
        {
            string username = User.Identity.Name ?? "";
            return Content(username);
        }
        return Content("No user");
    }

    public async Task<IActionResult> GetUserId()
    {
        if (User.Identity!.IsAuthenticated)
        {
            string username = User.Identity.Name ?? "";
            ApplicationUser? user = await _userRepo.ReadByUsernameAsync(username);
            if (user != null)
            {
                return Content(user.Id);
            }
        }
        return Content("No User");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
