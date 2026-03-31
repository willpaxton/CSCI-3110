using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lab4WPJSDOM.Models;

namespace Lab4WPJSDOM.Controllers;

public class MovieController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
