using Api.Base;
using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Features;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers.v2;


[ApiController]
[AllowAnonymous]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class InventoryController(IMediator mediator) : AppControllerBase
{    //-------------------------------
    #region Inventory APIs
    //-------------------------------
    [HttpPost("add-inventory")]
    public async Task<IActionResult> AddInventory([FromBody] AddInventoryRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-inventory/{id}")]
    public async Task<IActionResult> GetInventory([FromRoute] int id)
    {
        var response = mediator.HandleById<InventoryResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-inventory")]
    public async Task<IActionResult> UpdateInventory([FromBody] UpdateInventoryRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-inventory")]
    public IActionResult GetAll(InventoryAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-inventory")]
    public async Task<IActionResult> DeleteInventory([FromBody] DeleteInventoryRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region StorageUnit APIs
    //-------------------------------
    [HttpPost("add-storage-unit")]
    public async Task<IActionResult> AddStorageUnit([FromBody] AddStorageUnitRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-storage-unit/{id}")]
    public async Task<IActionResult> GetStorageUnit([FromRoute] int id)
    {
        var response = mediator.HandleById<StorageUnitResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-storage-unit")]
    public async Task<IActionResult> UpdateStorageUnit([FromBody] UpdateStorageUnitRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-storage-unit")]
    public IActionResult GetAll(StorageUnitAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-storage-unit")]
    public async Task<IActionResult> DeleteStorageUnit([FromBody] DeleteStorageUnitRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion


}
