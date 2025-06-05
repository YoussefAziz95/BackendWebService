using Infrastructure.Identity.Identity.PermissionManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Asp.Versioning;
using Application.Features;
using WebFramework.BaseController;
using WebFramework.WebExtensions;
using Mediator;

namespace Web.Api.Controllers.V1.Admin
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/OrderManagement")]
    [Display(Description= "Managing Users related Orders")]
    [Authorize(ConstantPolicies.DynamicPermission)]
    public class OrderManagementController : BaseController
    {
        private readonly ISender _sender;

        public OrderManagementController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("OrderList")]
        public async Task<IActionResult> GetOrders()
        {
            var queryResult = await _sender.Send(new GetAllOrdersQuery());

            return base.IResponse(queryResult);
        }
    }
}
