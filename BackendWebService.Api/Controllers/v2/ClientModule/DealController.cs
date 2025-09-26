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
public class DealController(IMediator mediator) : AppControllerBase
{
    //-------------------------------
    #region Deal APIs
    //-------------------------------
    [HttpPost("add-deal")]
    public async Task<IActionResult> AddDeal([FromBody] AddDealRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-deal/{id}")]
    public IActionResult GetDeal([FromRoute] int id)
    {
        var response = mediator.HandleById<DealResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-deal")]
    public async Task<IActionResult> UpdateDeal([FromBody] UpdateDealRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-deal")]
    public IActionResult GetAll(DealAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-deal")]
    public async Task<IActionResult> DeleteDeal([FromBody] DeleteDealRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region DealDetails APIs
    //-------------------------------
    [HttpPost("add-deal-details")]
    public async Task<IActionResult> AddDealDetails([FromBody] AddDealDetailsRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-deal-details/{id}")]
    public IActionResult GetDealDetails([FromRoute] int id)
    {
        var response = mediator.HandleById<DealDetailsResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-deal-details")]
    public async Task<IActionResult> UpdateDealDetails([FromBody] UpdateDealDetailsRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-deal-details")]
    public IActionResult GetAll(DealDetailsAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-deal-details")]
    public async Task<IActionResult> DeleteDealDetails([FromBody] DeleteDealDetailsRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region DealDocument APIs
    //-------------------------------
    [HttpPost("add-deal-document")]
    public async Task<IActionResult> AddDealDocument([FromBody] AddDealDocumentRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-deal-document/{id}")]
    public IActionResult GetDealDocument([FromRoute] int id)
    {
        var response = mediator.HandleById<DealDocumentResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-deal-document")]
    public async Task<IActionResult> UpdateDealDocument([FromBody] UpdateDealDocumentRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-deal-document")]
    public IActionResult GetAll(DealDocumentAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-deal-document")]
    public async Task<IActionResult> DeleteDealDocument([FromBody] DeleteDealDocumentRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion
}
