using Api.Base;
using Application.Contracts.Features;
using Application.Features;
using Microsoft.AspNetCore.Mvc;
namespace Api.Controllers.v2;


[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class SupplierController(IMediator mediator) : AppControllerBase
{

    //-------------------------------
    #region Supplier APIs
    //-------------------------------
    [HttpPost("add-supplier")]
    public async Task<IActionResult> AddSupplier([FromBody] AddSupplierRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-supplier/{id}")]
    public IActionResult GetSupplier([FromRoute] int id)
    {
        var response = mediator.HandleById<SupplierResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-supplier")]
    public async Task<IActionResult> UpdateSupplier([FromBody] UpdateSupplierRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-supplier")]
    public IActionResult GetAll(SupplierAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-supplier")]
    public async Task<IActionResult> DeleteSupplier([FromBody] DeleteSupplierRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region PreDocument APIs
    //-------------------------------
    [HttpPost("add-pre-document")]
    public async Task<IActionResult> AddPreDocument([FromBody] AddPreDocumentRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-pre-document/{id}")]
    public IActionResult GetPreDocument([FromRoute] int id)
    {
        var response = mediator.HandleById<PreDocumentResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-pre-document")]
    public async Task<IActionResult> UpdatePreDocument([FromBody] UpdatePreDocumentRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-pre-document")]
    public IActionResult GetAll(PreDocumentAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-pre-document")]
    public async Task<IActionResult> DeletePreDocument([FromBody] DeletePreDocumentRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion


    //-------------------------------
    #region SupplierAccount APIs
    //-------------------------------
    [HttpPost("add-supplier-account")]
    public async Task<IActionResult> AddSupplierAccount([FromBody] AddSupplierAccountRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-supplier-account/{id}")]
    public IActionResult GetSupplierAccount([FromRoute] int id)
    {
        var response = mediator.HandleById<SupplierAccountResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-supplier-account")]
    public async Task<IActionResult> UpdateSupplierAccount([FromBody] UpdateSupplierAccountRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-supplier-account")]
    public IActionResult GetAll(SupplierAccountAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-supplier-account")]
    public async Task<IActionResult> DeleteSupplierAccount([FromBody] DeleteSupplierAccountRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion



    //-------------------------------
    #region SupplierCategory APIs
    //-------------------------------
    [HttpPost("add-supplier-category")]
    public async Task<IActionResult> AddSupplierCategory([FromBody] AddSupplierCategoryRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-supplier-category/{id}")]
    public IActionResult GetSupplierCategory([FromRoute] int id)
    {
        var response = mediator.HandleById<SupplierCategoryResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-supplier-category")]
    public async Task<IActionResult> UpdateSupplierCategory([FromBody] UpdateSupplierCategoryRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-supplier-category")]
    public IActionResult GetAll(SupplierCategoryAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-supplier-category")]
    public async Task<IActionResult> DeleteSupplierCategory([FromBody] DeleteSupplierCategoryRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

}
