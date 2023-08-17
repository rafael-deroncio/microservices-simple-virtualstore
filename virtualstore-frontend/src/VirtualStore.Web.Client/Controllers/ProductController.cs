using Microsoft.AspNetCore.Mvc;
using VirtualStore.Web.Core.Configurations.Enum;
using VirtualStore.Web.Core.Models;
using VirtualStore.Web.Core.Services.Interfaces;

namespace VirtualStore.Web.Client.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ActionResult<IEnumerable<ProductViewModel>>> Index()
        {
            if (User.IsInRole(nameof(Role.MicroserviceRequestClient)))
            {
                IEnumerable<ProductViewModel> products = await _productService.GetProductsAsync();
                if (products.Any())
                    return View(products);
            }

            return View("Error");
        }
    }
}
