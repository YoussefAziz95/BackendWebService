using Asp.Versioning;
using Application.Features;
using Application.Features;
using WebFramework.BaseController;
using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers.V1;

[ApiVersion("1")]
[ApiController]
[Route("api/v{version:apiVersion}/User")]
[Authorize]
public class OrderController(ISender sender) : BaseController
{
    [HttpPost("CreateNewOrder")]
    public async Task<IActionResult> CreateNewOrder(AddOrderCommand model)
    {
        model.UserId = base.UserId;
        var command = await sender.Send(model);

        return base.IResponse(command);
    }

    [HttpGet("GetUserOrders")]
    public async Task<IActionResult> GetUserOrders()
    {
        var query = await sender.Send(new GetUserOrdersQueryModel(UserId));

        return base.IResponse(query);
    }

    [HttpPut("UpdateOrder")]
    public async Task<IActionResult> UpdateOrder(UpdateUserOrderCommand model)
    {
        model.UserId = base.UserId;

        var command = await sender.Send(model);

        return base.IResponse(command);
    }

    [HttpDelete("DeleteAllUserOrders")]
    public async Task<IActionResult> DeleteAllUserOrders()
        => base.IResponse(await sender.Send(new DeleteUserOrdersCommand(base.UserId)));
}