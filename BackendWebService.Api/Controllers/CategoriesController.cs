using Api.Base;
using Application.Contracts.Persistences;
using Application.Contracts.Services;
using Application.DTOs;
using Application.DTOs.Common;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class CategoriesController : AppControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileSystemService _fileSystemService;

    public CategoriesController(IUnitOfWork unitOfWork,
        IFileSystemService fileSystemService)
    {
        _unitOfWork = unitOfWork;
        _fileSystemService = fileSystemService;
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory([FromBody] AddCategoryRequest request)
    {
        var category = new Category
        {
            Name = request.Name,
            ParentId = request.ParentId
        };
        if (!_unitOfWork.GenericRepository<FileLog>().Exists(f => f.Id == request.FileId))
            return NotFound("Product not found");
        category.File = _unitOfWork.GenericRepository<FileLog>().GetById(request.FileId);
        category.Image = category.File.FullPath;
        category.FileId = request.FileId;
        _unitOfWork.GenericRepository<Category>().Add(category);
        var result = _unitOfWork.Save();
        return Ok(category.Id);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory([FromRoute] int id)
    {
        var category = _unitOfWork.GenericRepository<Category>().Get(c => c.Id == id, include: f => f.Include(l => l.File));
        if (category == null)
            return NotFound("Category not found");
        if (category.File == null)
            return NotFound("File not found");
        var result = new Response<CategoryResponse>()
        {
            Data = new CategoryResponse(category.Id, category.Name, category.ParentId, _fileSystemService.DownloadFileResponse(category.FileId), category.IsActive),
            StatusCode = ApiResultStatusCode.Success,
            Succeeded = true,
            Message = "Category found"
        };
        return NewResult(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryRequest request)
    {
        var category = await _unitOfWork.GenericRepository<Category>().GetByIdAsync(request.Id);
        if (category == null)
            return NotFound("Category not found");
        category.Name = request.Name;
        category.ParentId = request.ParentId;
        if (category.FileId is not null && category.FileId != request.FileId)
        {
            if (!_unitOfWork.GenericRepository<FileLog>().Exists(f => f.Id == request.FileId))
                _fileSystemService.DeleteFileById(category.FileId??0);
        }
        if (!_unitOfWork.GenericRepository<FileLog>().Exists(f => f.Id == request.FileId))
            return NotFound("File not found");
        category.File = _unitOfWork.GenericRepository<FileLog>().GetById(request.FileId);
        category.Image = category.File.FullPath;
        category.FileId = request.FileId;

        _unitOfWork.GenericRepository<Category>().Update(category);
        var result = _unitOfWork.Save();
        if (result == null)
            return NotFound("Category not found");
        var response = new Response<CategoryResponse>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Category updated successfully",
            Succeeded = true,
            Data = new CategoryResponse(category.Id, category.Name, category.ParentId, _fileSystemService.DownloadFileResponse(category.FileId), category.IsActive)
        };
        return NewResult(response);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var categories = _unitOfWork.GenericRepository<Category>().GetAll();
        if (categories == null)
            return NotFound("Categories not found");
        var result = new Response<List<CategoryResponse>>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Categories found",
            Succeeded = true,
            Data = categories.Select(c => new CategoryResponse(c.Id, c.Name, c.ParentId, _fileSystemService.DownloadFileResponse(c.FileId), c.IsActive)).ToList()
        };
        return NewResult(result);
    }

    [HttpGet("GetByParentId/{id?}")]
    public async Task<IActionResult> GetByParentId([FromRoute] int? id = null)
    {

        var categories = _unitOfWork.GenericRepository<Category>().GetAll(c => c.ParentId == id, include: c => c.Include(s => s.SubCategories));
        if (categories == null)
            return NotFound("Categories not found");
        var hasChildCategories = categories.Select(category => (c: category, hasChild: category.SubCategories is not null));
        var result = new Response<List<CategoryHasChildResponse>>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Categories found",
            Succeeded = true,
            Data = hasChildCategories.Select(c => new CategoryHasChildResponse(c.c.Id, c.c.Name, c.c.ParentId, _fileSystemService.DownloadFileResponse(c.c.FileId), c.hasChild, c.c.IsActive)).ToList()
        };
        return NewResult(result);
    }
}
