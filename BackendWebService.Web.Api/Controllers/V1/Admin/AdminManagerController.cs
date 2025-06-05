using Asp.Versioning;
using Application.Features.Admin.Commands.AddAdminCommand;
using Application.Features.Admin.Queries.GetToken;
using WebFramework.BaseController;
using WebFramework.WebExtensions;
using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers.V1.Admin
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/AdminManager")]
    public class AdminManagerController(ISender sender) : BaseController
    {
        [HttpPost("Login")]
        public async Task<IActionResult> AdminLogin(AdminGetTokenQuery model)
        {
            var query = await sender.Send(model);

            return base.IResponse(query);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("NewAdmin")]
        public async Task<IActionResult> AddNewAdmin(AddAdminCommand model)
        {
            var commandResult = await sender.Send(model);

            return base.IResponse(commandResult);
        }
    }
}
