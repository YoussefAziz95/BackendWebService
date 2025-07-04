﻿using Infrastructure.Identity.Identity.PermissionManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Asp.Versioning;
using Application.Features.Users.Queries.GetUsers;
using WebFramework.BaseController;
using WebFramework.WebExtensions;
using Mediator;

namespace Web.Api.Controllers.V1.Admin
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/UserManagement")]
    [Display(Description = "Managing API Users")]
    [Authorize(ConstantPolicies.DynamicPermission)]
    public class UserManagementController : BaseController
    {
        private readonly ISender _sender;

        public UserManagementController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("CurrentUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var queryResult = await _sender.Send(new GetUsersQuery());

            return base.IResponse(queryResult);
        }
    }
}
