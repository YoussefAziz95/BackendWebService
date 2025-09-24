using Api.Base;
using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Contracts.Services;
using Application.Features;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v2;


[ApiController]
[AllowAnonymous]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ProductController(IMediator mediator) : AppControllerBase
{

    //-------------------------------
    #region Part APIs
    //-------------------------------
    [HttpPost("add-part")]
    public async Task<IActionResult> AddPart([FromBody] AddPartRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-part/{id}")]
    public async Task<IActionResult> GetPart([FromRoute] int id)
    {
        var response = mediator.HandleById<PartResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-part")]
    public async Task<IActionResult> UpdatePart([FromBody] UpdatePartRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-part")]
    public IActionResult GetAll(PartAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-part")]
    public async Task<IActionResult> DeletePart([FromBody] DeletePartRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region Product APIs
    //-------------------------------
    [HttpPost("add-product")]
    public async Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-product/{id}")]
    public async Task<IActionResult> GetProduct([FromRoute] int id)
    {
        var response = mediator.HandleById<ProductResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-product")]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-product")]
    public IActionResult GetAll(ProductAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-product")]
    public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region Spare APIs
    //-------------------------------
    [HttpPost("add-spare")]
    public async Task<IActionResult> AddSpare([FromBody] AddSpareRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-spare/{id}")]
    public async Task<IActionResult> GetSpare([FromRoute] int id)
    {
        var response = mediator.HandleById<SpareResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-spare")]
    public async Task<IActionResult> UpdateSpare([FromBody] UpdateSpareRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-spare")]
    public IActionResult GetAll(SpareAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-spare")]
    public async Task<IActionResult> DeleteSpare([FromBody] DeleteSpareRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region SparePart APIs
    //-------------------------------
    [HttpPost("add-spare-part")]
    public async Task<IActionResult> AddSparePart([FromBody] AddSparePartRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-spare-part/{id}")]
    public async Task<IActionResult> GetSparePart([FromRoute] int id)
    {
        var response = mediator.HandleById<SparePartResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-spare-part")]
    public async Task<IActionResult> UpdateSparePart([FromBody] UpdateSparePartRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-spare-part")]
    public IActionResult GetAll(SparePartAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-spare-part")]
    public async Task<IActionResult> DeleteSparePart([FromBody] DeleteSparePartRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion
}
