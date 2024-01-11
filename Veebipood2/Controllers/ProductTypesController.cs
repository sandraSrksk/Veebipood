using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Veebipood2.Data;
using Veebipood2.Services;

namespace Veebipood2.Controllers
{
    public class ProductTypesController : Controller
    {
        private readonly IProductTypeService _productTypeService;

        public ProductTypesController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        // GET: ProductTypes
        public async Task<IActionResult> Index(int page = 1)
        {
            var result = await _productTypeService.List(page, 3);
            return View(result);
        }

        // GET: ProductTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await _productTypeService.GetById(id.Value);
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }

        // GET: ProductTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeName")] ProductType productType)
        {
            if (ModelState.IsValid)
            {
                return View(productType);
            }
            await _productTypeService.Save(productType);
            return RedirectToAction(nameof(Index));
        }

        // GET: ProductTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await _productTypeService.GetById(id.Value);
            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }

        // POST: ProductTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeName")] ProductType productType)
        {
            if (id != productType.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(productType);
            }
                _productTypeService.Save(productType);
                return RedirectToAction(nameof(Index));
        }

        // GET: ProductTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await _productTypeService.GetById(id.Value);
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productTypeService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}