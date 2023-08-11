using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualStore.Catalog.Core.Configurations.Enums;

namespace VirtualStore.Catalog.API.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
[Authorize]
public class ProductController : Controller
{
    [HttpGet("{id:int}")]
    [Authorize(Roles = nameof(RoleEnum.MicroserviceRequestClient))]
    //[ProducesResponseType(typeof(CursoResponse), StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    //[ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetProduct(int id)
    {
        return Ok();
    }

    [HttpGet]
    [Authorize(Roles = nameof(RoleEnum.MicroserviceRequestClient))]
    //[ProducesResponseType(typeof(IEnumerable<CursoResponse>), StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    //[ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetProducts()
    {
        return Ok();
    }

    [HttpPost]
    [Authorize(Roles = nameof(RoleEnum.MicroserviceRequestClient))]
    //[ProducesResponseType(typeof(NovoCursoResponse), StatusCodes.Status201Created)]
    //[ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    //[ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> RegisterProduct()
    {
        return Ok();
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = nameof(RoleEnum.MicroserviceRequestClient))]
    //[ProducesResponseType(typeof(CursoResponse), StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    //[ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> UpdateProduct()
    {
        return Ok();
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = nameof(RoleEnum.MicroserviceRequestClient))]
    //[ProducesResponseType(typeof(bool), StatusCodes.Status204NoContent)]
    //[ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
    //[ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> DeleteProdruct()
    {
        return Ok();
    }
}