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

    public IActionResult Create() 
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product newProduct, IList<IFormFile> imageFiles)
    {
        // Get the first image in the list.
        IFormFile? imageFile = imageFiles.FirstOrDefault();
        if (imageFile == null || imageFile.Length <= 0)
        {
            newProduct.ImageData = null;
            newProduct.ImageMIMEType = "";
        }
        else
        {
            using MemoryStream ms = new();
            await imageFile.OpenReadStream().CopyToAsync(ms);
            newProduct.ImageData = ms.ToArray();
            newProduct.ImageMIMEType = imageFile.ContentType;
        }
        if (ModelState.IsValid)
        {
            await _productRepo.CreateAsync(newProduct);
            return RedirectToAction("Index");
        }
        newProduct.ImageData = null;
        newProduct.ImageMIMEType = "";
        return View(newProduct);
    }

}