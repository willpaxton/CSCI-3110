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

    public async Task<IActionResult> Details(int id)
    {
        Product? product = await _productRepo.ReadAsync(id);
        if (product == null)
        {
            return RedirectToAction("Index");
        }
        return View(product);
    }

    public async Task<IActionResult> Image(int id)
    {
        var product = await _productRepo.ReadAsync(id);
        if (product == null || product.ImageData == null)
        {
            var svg = @"<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>
                        <rect width='100' height='100' fill='#cccccc'/>
                        <text x='25%' y='25%' text-anchor='middle' dominant-baseline='middle'
                        font-family='Arial' font-size='16' fill='#666666'>No Image</text>
                        </svg>";
            return Content(svg, "image/svg+xml");
        }
        MemoryStream ms = new(product.ImageData);
        return new FileStreamResult(ms, product.ImageMIMEType);
    }

    public async Task<IActionResult> Edit(int id)
    {
        Product? product = await _productRepo.ReadAsync(id);
        if (product == null)
        {
            return RedirectToAction("Index");
        }
        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Product productToUpdate, IList<IFormFile> imageFiles)
    {
        // Get the first image in the list.
        IFormFile? imageFile = imageFiles.FirstOrDefault();
        if (imageFile != null && imageFile.Length > 0)
        {
            using MemoryStream ms = new();
            await imageFile.OpenReadStream().CopyToAsync(ms);
            productToUpdate.ImageData = ms.ToArray();
            productToUpdate.ImageMIMEType = imageFile.ContentType;
        }
        else
        {
            // Load the previous image information
            var product = await _productRepo.ReadAsync(productToUpdate.Id);
            productToUpdate.ImageData = product!.ImageData;
            productToUpdate.ImageMIMEType = product!.ImageMIMEType;
        }
        // Complete the implementation here
        if (ModelState.IsValid)
        {
            await _productRepo.UpdateAsync(productToUpdate.Id, productToUpdate);
            return RedirectToAction("Index");
        }
        return View(productToUpdate);
    }


    public async Task<IActionResult> Delete(int id)
    {
        Product? product = await _productRepo.ReadAsync(id);
        if (product == null)
        {
            return RedirectToAction("Index");
        }
        return View(product);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _productRepo.DeleteAsync(id);
        return RedirectToAction("Index");
    }

}