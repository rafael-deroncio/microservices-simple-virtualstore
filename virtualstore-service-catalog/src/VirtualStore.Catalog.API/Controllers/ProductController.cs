using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualStore.Catalog.Core.Configurations.Enums;
using VirtualStore.Catalog.Core.Responses;
using VirtualStore.Catalog.Domain.Requests;
using VirtualStore.Catalog.Domain.Responses;

namespace VirtualStore.Catalog.API.Controllers;

/// <summary>
/// Represents the API endpoint for managing products.
/// </summary>
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
[Authorize]
public class ProductController : Controller
{
    /// <summary>
    /// Retrieves a product by its ID.
    /// </summary>
    /// <param name="id">The ID of the product.</param>
    /// <returns>An action result representing the response.</returns>
    [HttpGet("{id:int}")]
    [Authorize(Roles = nameof(RoleEnum.MicroserviceRequestClient))]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetProduct(int id) => Ok();

    /// <summary>
    /// Retrieves a list of products.
    /// </summary>
    /// <returns>An action result representing the response.</returns>
    [HttpGet]
    [Authorize(Roles = nameof(RoleEnum.MicroserviceRequestClient))]
    [ProducesResponseType(typeof(IEnumerable<ProductResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetProducts() => Ok();

    /// <summary>
    /// Creates a new product.
    /// </summary>
    /// <param name="request">The product information to create.</param>
    /// <returns>An action result representing the response.</returns>
    [HttpPost]
    [Authorize(Roles = nameof(RoleEnum.MicroserviceRequestClient))]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> PostProduct([FromBody] ProductRequest request) => Ok();

    /// <summary>
    /// Updates an existing product.
    /// </summary>
    /// <param name="id">The ID of the product to update.</param>
    /// <param name="request">The updated product information.</param>
    /// <returns>An action result representing the response.</returns>
    [HttpPut("{id:int}")]
    [Authorize(Roles = nameof(RoleEnum.MicroserviceRequestClient))]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> UpdateProduct(int id, [FromBody] ProductRequest request) => Ok();

    /// <summary>
    /// Deletes a product by its ID.
    /// </summary>
    /// <param name="id">The ID of the product to delete.</param>
    /// <returns>An action result representing the response.</returns>
    [HttpDelete("{id:int}")]
    [Authorize(Roles = nameof(RoleEnum.MicroserviceRequestClient))]
    [ProducesResponseType(typeof(bool), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> DeleteProduct(int id) => Ok();
}