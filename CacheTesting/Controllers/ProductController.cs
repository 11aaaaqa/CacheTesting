using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Web.Repositories;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private ProductRepository repository;

        public ProductController(ProductRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Products()
        {
            var products = await repository.GetAll();

            return View(products);
        }

        [HttpGet]
        public IActionResult GetProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            Product product = null;
            try
            {
                product = await repository.Get(id);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty,e.Message);
            }
            
            return View(product);
        }
    }
}
