﻿using Application.Contracts.Services;
using Application.DTOs.Common;
using Application.DTOs.PreDocuments;
using Application.Validators.Common;
using Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.Base;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PreDocumentsController : AppControllerBase
{
    private readonly IPreDocumentService _preDocumentService;

    public PreDocumentsController(IPreDocumentService preDocumentService)
    {
        _preDocumentService = preDocumentService;
    }

    [HttpPost]
    //[Authorize(PermissionConstants.PREDOCUMENT)]
    [ModelValidator]
    public async Task<IActionResult> AddPreDocument([FromBody] AddPreDocumentRequest request)
    {
        var result = await _preDocumentService.AddAsync(request);
        return NewResult(result);
    }

    [HttpGet("{id}")]
    [Authorize(PermissionConstants.PREDOCUMENT)]
    public async Task<IActionResult> GetPreDocument([FromRoute] int id)
    {
        var result = await _preDocumentService.GetAsync(id);
        return NewResult(result);
    }

    [HttpDelete("{id}")]
    [Authorize(PermissionConstants.PREDOCUMENT)]
    public async Task<IActionResult> DeletePreDocument([FromRoute] int id)
    {
        var result = await _preDocumentService.DeleteAsync(id);
        return NewResult(result);
    }

    [HttpPut("{id}")]
    //[Authorize(PermissionConstants.PREDOCUMENT)]
    [ModelValidator]
    public async Task<IActionResult> UpdatePreDocument([FromRoute] int id, [FromBody] UpdatePreDocumentRequest request)
    {
        var result = await _preDocumentService.UpdateAsync(id, request);
        return NewResult(result);
    }

    [HttpPost("GetAll")]
    [Authorize(PermissionConstants.PREDOCUMENT)]
    public async Task<IActionResult> GetAll([FromBody] GetPaginatedRequest request)
    {
        var result = await _preDocumentService.GetPaginated(request);
        return Ok(result);
    }

    [HttpGet]
    [Authorize(PermissionConstants.PREDOCUMENT)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _preDocumentService.GetAllAsync();
        return Ok(result);
    }
}
