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
public class EmailControllerController(IMediator mediator) : AppControllerBase
{

    //-------------------------------
    #region Attachment APIs
    //-------------------------------
    [HttpPost("add-attachment")]
    public async Task<IActionResult> AddAttachment([FromBody] AddAttachmentRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-attachment/{id}")]
    public async Task<IActionResult> GetAttachment([FromRoute] int id)
    {
        var response = mediator.HandleById<AttachmentResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-attachment")]
    public async Task<IActionResult> UpdateAttachment([FromBody] UpdateAttachmentRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-attachment")]
    public IActionResult GetAll(AttachmentAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-attachment")]
    public async Task<IActionResult> DeleteAttachment([FromBody] DeleteAttachmentRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region EmailLog APIs
    //-------------------------------
    [HttpPost("add-email-log")]
    public async Task<IActionResult> AddEmailLog([FromBody] AddEmailLogRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-email-log/{id}")]
    public async Task<IActionResult> GetEmailLog([FromRoute] int id)
    {
        var response = mediator.HandleById<EmailLogResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-email-log")]
    public async Task<IActionResult> UpdateEmailLog([FromBody] UpdateEmailLogRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-email-log")]
    public IActionResult GetAll(EmailLogAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-email-log")]
    public async Task<IActionResult> DeleteEmailLog([FromBody] DeleteEmailLogRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region Recipient APIs
    //-------------------------------
    [HttpPost("add-recipient")]
    public async Task<IActionResult> AddRecipient([FromBody] AddRecipientRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-recipient/{id}")]
    public async Task<IActionResult> GetRecipient([FromRoute] int id)
    {
        var response = mediator.HandleById<RecipientResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-recipient")]
    public async Task<IActionResult> UpdateRecipient([FromBody] UpdateRecipientRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-recipient")]
    public IActionResult GetAll(RecipientAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-recipient")]
    public async Task<IActionResult> DeleteRecipient([FromBody] DeleteRecipientRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion


}
