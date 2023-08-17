using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualStore.Catalog.Core.Configurations.Enums;
using VirtualStore.Catalog.Core.Responses;
using VirtualStore.Catalog.Core.Services.Interfaces;
using VirtualStore.Catalog.Domain.Requests;
using VirtualStore.Catalog.Domain.Responses;

namespace VirtualStore.Catalog.API.Controllers;

/// <summary>
/// Represents the API endpoint for managing categories.
/// </summary>
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
[Authorize]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryController"/> class.
    /// </summary>
    /// <param name="categoryService">The category service instance used for category management operations.</param>
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    /// <summary>
    /// Retrieves a category by its ID.
    /// </summary>
    /// <param name="id">The ID of the category.</param>
    /// <returns>An action result representing the response.</returns>
    [HttpGet("{id:int}")]
    [Authorize(Roles = nameof(Role.MicroserviceRequestClient))]
    [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetCategory(int id) 
        => Ok(await _categoryService.GetCategory(id));

    /// <summary>
    /// Retrieves a list of categories.
    /// </summary>
    /// <returns>An action result representing the response.</returns>
    [HttpGet]
    [Authorize(Roles = nameof(Role.MicroserviceRequestClient))]
    [ProducesResponseType(typeof(IEnumerable<CategoryResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetCategories() 
        => Ok(await _categoryService.GetCategories());

    /// <summary>
    /// Creates a new category.
    /// </summary>
    /// <param name="request">The category information to create.</param>
    /// <returns>An action result representing the response.</returns>
    [HttpPost]
    [Authorize(Roles = nameof(Role.MicroserviceRequestClient))]
    [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> PostCategory([FromBody] CategoryRequest request) 
        => Ok(await _categoryService.CreateCategory(request));

    /// <summary>
    /// Updates an existing category.
    /// </summary>
    /// <param name="id">The ID of the category to update.</param>
    /// <param name="request">The updated category information.</param>
    /// <returns>An action result representing the response.</returns>
    [HttpPut("{id:int}")]
    [Authorize(Roles = nameof(Role.MicroserviceRequestClient))]
    [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> UpdateCategory(int id, [FromBody] CategoryRequest request) 
        => Ok(await _categoryService.UpdateCategory(id, request));

    /// <summary>
    /// Deletes a category by its ID.
    /// </summary>
    /// <param name="id">The ID of the category to delete.</param>
    /// <returns>An action result representing the response.</returns>
    [HttpDelete("{id:int}")]
    [Authorize(Roles = nameof(Role.MicroserviceRequestClient))]
    [ProducesResponseType(typeof(bool), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> DeleteCategory(int id) 
        => Ok(await _categoryService.DeleteCategory(id));
}