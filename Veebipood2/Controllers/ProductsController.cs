
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Veebipood2.Data;
using Veebipood2.Data.Queries;
using Veebipood2.Services;

namespace Veebipood2.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductTypeService _productTypeService;

        public ProductsController(IProductService productService, IProductTypeService productTypeService)
        {
            _productService = productService;
            _productTypeService = productTypeService;
        }

        // GET: Products
        public async Task<IActionResult> Index(int page = 1, ProductQuery query = null)
        {
            var items = new PagedResult<Product>();
            if (!query.IsEmpty())
            {
                items = await _productService.List(page, pageSize: 5, query);
            }
            await FillProductTypes(query.TypeId);

            return View(items);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetById(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            await FillProductTypes(null);
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,TypeName, ProductTypeId")] Product product)
        {
            ModelState.Remove("ProductType");
            if (ModelState.IsValid)
            {
                await _productService.Save(product);
                return RedirectToAction(nameof(Index));
            }

            //var items = await _productTypeService.Lookup();
            //ViewData["ProductTypeId"] = new SelectList(items, "Id", "TypeName");
            await FillProductTypes(null);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetById(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            //var items = await _productTypeService.Lookup();
            //ViewData["ProductTypeId"] = new SelectList(items, "Id", "TypeName" , product.ProductTypeId);
            await FillProductTypes(product.ProductTypeId);

            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            var productInDb = await _productService.GetById(id);
            productInDb.Description = product.Description;
            productInDb.Name = product.Name;
            productInDb.Price = product.Price;
            productInDb.ProductTypeId = product.ProductTypeId;

            if (ModelState.IsValid)
            {
                await _productService.Save(product);
                return RedirectToAction(nameof(Index));

            }
            await FillProductTypes(product.ProductTypeId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetById(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await _productService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        private async Task FillProductTypes(int? productTypeId)
        {
            var items = await _productTypeService.Lookup();
            var selectType = new SelectList(items, "Id", "TypeName", productTypeId);

            ViewData["ProductTypeId"] = selectType;
        }
    }
}