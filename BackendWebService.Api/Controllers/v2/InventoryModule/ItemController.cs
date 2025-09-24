using Api.Base;
using Application.Contracts.Features;
using Application.Features;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v2;


[ApiController]
[AllowAnonymous]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ItemController(IMediator mediator) : AppControllerBase
{
    //-------------------------------
    #region Item APIs
    //-------------------------------
    [HttpPost("add-item")]
    public async Task<IActionResult> AddItem([FromBody] AddItemRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-item/{id}")]
    public async Task<IActionResult> GetItem([FromRoute] int id)
    {
        var response = mediator.HandleById<ItemResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-item")]
    public async Task<IActionResult> UpdateItem([FromBody] UpdateItemRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-item")]
    public IActionResult GetAll(ItemAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-item")]
    public async Task<IActionResult> DeleteItem([FromBody] DeleteItemRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region Portion APIs
    //-------------------------------
    [HttpPost("add-portion")]
    public async Task<IActionResult> AddPortion([FromBody] AddPortionRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-portion/{id}")]
    public async Task<IActionResult> GetPortion([FromRoute] int id)
    {
        var response = mediator.HandleById<PortionResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-portion")]
    public async Task<IActionResult> UpdatePortion([FromBody] UpdatePortionRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-portion")]
    public IActionResult GetAll(PortionAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-portion")]
    public async Task<IActionResult> DeletePortion([FromBody] DeletePortionRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region PortionItem APIs
    //-------------------------------
    [HttpPost("add-portion-item")]
    public async Task<IActionResult> AddPortionItem([FromBody] AddPortionItemRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-portion-item/{id}")]
    public async Task<IActionResult> GetPortionItem([FromRoute] int id)
    {
        var response = mediator.HandleById<PortionItemResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-portion-item")]
    public async Task<IActionResult> UpdatePortionItem([FromBody] UpdatePortionItemRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-portion-item")]
    public IActionResult GetAll(PortionItemAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-portion-item")]
    public async Task<IActionResult> DeletePortionItem([FromBody] DeletePortionItemRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region PortionType APIs
    //-------------------------------
    [HttpPost("add-portion-type")]
    public async Task<IActionResult> AddPortionType([FromBody] AddPortionTypeRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-portion-type/{id}")]
    public async Task<IActionResult> GetPortionType([FromRoute] int id)
    {
        var response = mediator.HandleById<PortionTypeResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-portion-type")]
    public async Task<IActionResult> UpdatePortionType([FromBody] UpdatePortionTypeRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-portion-type")]
    public IActionResult GetAll(PortionTypeAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-portion-type")]
    public async Task<IActionResult> DeletePortionType([FromBody] DeletePortionTypeRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion
}
