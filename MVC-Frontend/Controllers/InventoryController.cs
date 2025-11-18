using Microsoft.AspNetCore.Mvc;
using MVC_Frontend.Models;

namespace MVC_Frontend.Controllers
{
    public class InventoryController : Controller
    {
        InventoryApiService _api;
        public InventoryController(InventoryApiService api)
        {
            _api = api;
        }
        public async Task<IActionResult> Index()
        {
            var inventory = await _api.GetAll();
            return View(inventory);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Inventory inventory)
        {
            if (await _api.Create(inventory))
                return RedirectToAction("Index");

            return View(inventory);
        }

        public async Task<IActionResult> Details(int id)
        {
            var inventory = await _api.GetById(id);
            return View(inventory);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var inventory = await _api.GetById(id);
            return View(inventory);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Inventory inventory)
        {
            if (await _api.Update(inventory))
                return RedirectToAction("Index");

            return View(inventory);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var inventory = await _api.GetById(id);
            return View(inventory);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await _api.Delete(id))
                return RedirectToAction("Index");

            return View();
        }
    }
}
