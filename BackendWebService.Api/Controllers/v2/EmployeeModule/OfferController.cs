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
public class OfferController(IMediator mediator) : AppControllerBase
{

    //-------------------------------
    #region Criteria APIs
    //-------------------------------
    [HttpPost("add-criteria")]
    public async Task<IActionResult> AddCriteria([FromBody] AddCriteriaRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-criteria/{id}")]
    public IActionResult GetCriteria([FromRoute] int id)
    {
        var response = mediator.HandleById<CriteriaResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-criteria")]
    public async Task<IActionResult> UpdateCriteria([FromBody] UpdateCriteriaRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-criteria")]
    public IActionResult GetAll(CriteriaAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-criteria")]
    public async Task<IActionResult> DeleteCriteria([FromBody] DeleteCriteriaRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region Offer APIs
    //-------------------------------
    [HttpPost("add-offer")]
    public async Task<IActionResult> AddOffer([FromBody] AddOfferRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-offer/{id}")]
    public IActionResult GetOffer([FromRoute] int id)
    {
        var response = mediator.HandleById<OfferResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-offer")]
    public async Task<IActionResult> UpdateOffer([FromBody] UpdateOfferRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-offer")]
    public IActionResult GetAll(OfferAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-offer")]
    public async Task<IActionResult> DeleteOffer([FromBody] DeleteOfferRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region OfferItem APIs
    //-------------------------------
    [HttpPost("add-offer-item")]
    public async Task<IActionResult> AddOfferItem([FromBody] AddOfferItemRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-offer-item/{id}")]
    public IActionResult GetOfferItem([FromRoute] int id)
    {
        var response = mediator.HandleById<OfferItemResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-offer-item")]
    public async Task<IActionResult> UpdateOfferItem([FromBody] UpdateOfferItemRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-offer-item")]
    public IActionResult GetAll(OfferItemAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-offer-item")]
    public async Task<IActionResult> DeleteOfferItem([FromBody] DeleteOfferItemRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region OfferObject APIs
    //-------------------------------
    [HttpPost("add-offer-object")]
    public async Task<IActionResult> AddOfferObject([FromBody] AddOfferObjectRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-offer-object/{id}")]
    public IActionResult GetOfferObject([FromRoute] int id)
    {
        var response = mediator.HandleById<OfferObjectResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-offer-object")]
    public async Task<IActionResult> UpdateOfferObject([FromBody] UpdateOfferObjectRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-offer-object")]
    public IActionResult GetAll(OfferObjectAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-offer-object")]
    public async Task<IActionResult> DeleteOfferObject([FromBody] DeleteOfferObjectRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion
}
