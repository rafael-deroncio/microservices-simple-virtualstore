using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VirtualStore.Web.Core.Configurations.Enum;
using VirtualStore.Web.Core.ViewModels;
using VirtualStore.Web.Core.Services.Interfaces;

namespace VirtualStore.Web.Client.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public ProductController(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductViewModel>>> Index() 
        => View(await _productService.GetProductsAsync());

    [HttpGet]
    public async Task<ActionResult<ProductViewModel>> Create()
    {
        if (User.IsInRole(nameof(Role.MicroserviceRequestClient)))
            return View("Unauthorized");

        ViewBag.Categorys = new SelectList(await _categoryService.GetCategorysAsync(), "Id", "Name");
        return View();
    }

    [HttpPost]
    public async Task<ActionResult<ProductViewModel>> Create(ProductViewModel product)
    {
        if (User.IsInRole(nameof(Role.MicroserviceRequestClient)))
            return View("Unauthorized");

        if (!ModelState.IsValid)
        {
            ViewBag.Categorys = new SelectList(await _categoryService.GetCategorysAsync(), "Id", "Name");

            TempData["message"] = MessageModelView.Serialize("Correct the fields to proceed.", MessageType.Information);

            return View(product);
        }

        TempData["message"] = (await _productService.CreateProductAsync(product) is not null)
        ? MessageModelView.Serialize("Product registered successfully!", MessageType.Success)
        : MessageModelView.Serialize("We were unable to process the request at this time.", MessageType.Error);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<ActionResult<ProductViewModel>> Edit(int? id)
    {
        if (User.IsInRole(nameof(Role.MicroserviceRequestClient)))
            return View("Unauthorized");

        if (id.HasValue && id.Value > 0)
        {
            ProductViewModel product = await _productService.GetProductAsync(id.Value);

            if (product != null)
                return View(product);
        }

        TempData["message"] = MessageModelView.Serialize($"ID {id.GetValueOrDefault()} is not valid for this request!", MessageType.Error);

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<ActionResult<ProductViewModel>> Edit(int? id, ProductViewModel product)
    {
        if (User.IsInRole(nameof(Role.MicroserviceRequestClient)))
            return View("Unauthorized");

        if (!id.HasValue || id.Value <= 0)
        {
            TempData["message"] = MessageModelView.Serialize($"ID {id.GetValueOrDefault()} is not valid for this request!", MessageType.Error);

            return RedirectToAction(nameof(Index));
        }

        if (!ModelState.IsValid)
        {
            TempData["message"] = MessageModelView.Serialize("Correct the fields to proceed.", MessageType.Information);

            return View(product);
        }

        TempData["message"] = await _productService.UpdateProductAsync(id.Value, product) != null
            ? MessageModelView.Serialize("Product updated successfully!", MessageType.Success)
            : MessageModelView.Serialize("We were unable to process the request at this time.", MessageType.Error);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<ActionResult<ProductViewModel>> Delete(int? id)
    {
        if (User.IsInRole(nameof(Role.MicroserviceRequestClient)))
            return View("Unauthorized");

        if (id.HasValue && id.Value > 0)
        {
            ProductViewModel product = await _productService.GetProductAsync(id.Value);

            if (product is not null)
                return View(product);
        }

        TempData["message"] = MessageModelView.Serialize($"ID {id.GetValueOrDefault()} is not valid for this request!", MessageType.Error);

        return RedirectToAction(nameof(Index));

    }

    [HttpPost]
    public async Task<ActionResult<ProductViewModel>> Delete(int? id, ProductViewModel product)
    {
        if (User.IsInRole(nameof(Role.MicroserviceRequestClient)))
            return View("Unauthorized");

        TempData["message"] = id.HasValue && id.Value == product.Id && await _productService.DeleteProductAsync(id.Value)
            ? MessageModelView.Serialize("Product deleted successfully!", MessageType.Success)
            : MessageModelView.Serialize($"Unable to delete product with ID {id.GetValueOrDefault()}", MessageType.Error);

        return RedirectToAction(nameof(Index));
    }
}