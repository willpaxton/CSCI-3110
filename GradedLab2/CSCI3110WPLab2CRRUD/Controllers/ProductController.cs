using Microsoft.AspNetCore.Mvc;
using CSCI3110WPLab2CRRUD.Models.Entities;
using CSCI3110WPLab2CRRUD.Services;

namespace CSCI3110WPLab2CRRUD.Controllers;

public class ProductController : Controller {
    public readonly IProductRepository _productRepo;

    public ProductController(IProductRepository productRepo) 
    {
        _productRepo = productRepo;
    }

    public async Task<IActionResult> Index()
    {
        var productModel = await _productRepo.ReadAllAsync();
        return View(productModel);
    }
}