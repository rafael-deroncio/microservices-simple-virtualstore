﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualStore.Catalog.Core.Responses;
using VirtualStore.Catalog.Core.Services.Interfaces;
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
    private readonly IProductService _productService;


    /// <summary>
    /// Initializes a new instance of the <see cref="ProductController"/> class.
    /// </summary>
    /// <param name="productService">The product service instance used for product management operations.</param>
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Retrieves a product by its ID.
    /// </summary>
    /// <param name="id">The ID of the product.</param>
    /// <returns>An action result representing the response.</returns>
    [HttpGet("{id:int}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetProduct(int id)
        => Ok(await _productService.GetProduct(id));

    /// <summary>
    /// Retrieves a paged list of products.
    /// </summary>
    /// <param name="pagination">contains 'page number' and 'page size' to pagination request</param>
    /// <returns>An action result representing the response.</returns>
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PaginationResponse<IEnumerable<ProductResponse>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetProducts([FromQuery] PaginationRequest pagination)
        => Ok(await _productService.GetProducts(pagination));

    /// <summary>
    /// Creates a new product.
    /// </summary>
    /// <param name="request">The product information to create.</param>
    /// <returns>An action result representing the response.</returns>
    [HttpPost]
    [Authorize(Roles = "Admin, Manager")]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> PostProduct([FromBody] ProductRequest request)
        => Ok(await _productService.CreateProduct(request));

    /// <summary>
    /// Updates an existing product.
    /// </summary>
    /// <param name="id">The ID of the product to update.</param>
    /// <param name="request">The updated product information.</param>
    /// <returns>An action result representing the response.</returns>
    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin, Manager")]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> UpdateProduct(int id, [FromBody] ProductRequest request)
        => Ok(await _productService.UpdateProduct(id, request));

    /// <summary>
    /// Deletes a product by its ID.
    /// </summary>
    /// <param name="id">The ID of the product to delete.</param>
    /// <returns>An action result representing the response.</returns>
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin, Manager")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> DeleteProduct(int id)
        => Ok(await _productService.DeleteProduct(id));
}