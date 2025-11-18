using Microsoft.AspNetCore.Mvc;
using MVC_Frontend.Models;

public class ProductController : Controller
{
    private readonly ProductApiService _api;

    public ProductController(ProductApiService api)
    {
        _api = api;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _api.GetAll();
        return View(products);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        if (await _api.Create(product))
            return RedirectToAction("Index");

        return View(product);
    }

    public async Task<IActionResult> Details(int id)
    {
        var product = await _api.GetById(id);
        return View(product);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var product = await _api.GetById(id);
        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Product product)
    {
        if (await _api.Update(product))
            return RedirectToAction("Index");

        return View(product);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var product = await _api.GetById(id);
        return View(product);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (await _api.Delete(id))
            return RedirectToAction("Index");

        return View();
    }
}
