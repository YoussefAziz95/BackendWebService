using Api.Base;
using Application.Contracts.Persistence;
using Application.Contracts.Services;
using Application.Features;
using Application.Features.Common;
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
        category.FileId = request.FileId;
        _unitOfWork.GenericRepository<Category>().Add(category);
        var result = _unitOfWork.Save();
        return Ok(category.Id);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory([FromRoute] int id)
    {
        var category = _unitOfWork.GenericRepository<Category>().Get(c => c.Id == id, include: f => f.Include(l => l.File));
        if (category is null)
            return NotFound("Category not found");
        if (category.File is null)
            return NotFound("File not found");
        var result = new Response<CategoryResponse>()
        {
            Data = new CategoryResponse(category.Id, category.Name, category.ParentId, _fileSystemService.DownloadFileResponse(category.File.FileName), category.IsActive),
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
        if (category is null)
            return NotFound("Category not found");
        category.Name = request.Name;
        category.ParentId = request.ParentId;
        if (category.FileId is not null && category.FileId != request.FileId)
        {
            if (!_unitOfWork.GenericRepository<FileLog>().Exists(f => f.Id == request.FileId))
                _fileSystemService.DeleteFile(category.File.FileName);
        }
        if (!_unitOfWork.GenericRepository<FileLog>().Exists(f => f.Id == request.FileId))
            return NotFound("File not found");
        category.File = _unitOfWork.GenericRepository<FileLog>().GetById(request.FileId);
        category.FileId = request.FileId;

        _unitOfWork.GenericRepository<Category>().Update(category);
        var result = _unitOfWork.Save();
        if (result == null)
            return NotFound("Category not found");
        var fileResponse = _fileSystemService.DownloadFileResponse(category.File.FileName);
        fileResponse.FileLink = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/api/FileSystem/file/download/{category.FileId}";
        var response = new Response<CategoryResponse>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Category updated successfully",
            Succeeded = true,
            Data = new CategoryResponse(category.Id, category.Name, category.ParentId, _fileSystemService.DownloadFileResponse(category.File.FileName), category.IsActive)
        };
        return NewResult(response);
    }

    [HttpGet("GetAll")]
    [ProducesResponseType(typeof(Response<List<CategoryWithFileResponse>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var categories = _unitOfWork.GenericRepository<Category>().GetAll();
        if (categories is null)
            return NotFound("Categories not found");
        // Get the server URL
        var categoriesReponse = new List<CategoryWithFileResponse>();
        foreach (var c in categories)
        {
            var fileResponse = _fileSystemService.DownloadFileResponse(c.File.FileName);
            fileResponse.FileLink = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/api/FileSystem/file/download/{c.FileId}";
            var categoryResponse =  new CategoryWithFileResponse(c.Id, c.Name, c.ParentId,fileResponse, c.IsActive);
            categoriesReponse.Add(categoryResponse);
        }
        var result = new Response<List<CategoryWithFileResponse>>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Categories found",
            Succeeded = true,
            Data = categoriesReponse
        };
        return NewResult(result);
    }

    [HttpGet("GetByParentId/{id?}")]
    public IActionResult GetByParentId([FromRoute] int? id = null)
    {

        var categories = _unitOfWork.GenericRepository<Category>().GetAll(c => c.ParentId == id, include: c => c.Include(s => s.SubCategories));
        if (categories is null)
            return NotFound("Categories not found");
        var hasChildCategories = categories.Select(category => (c: category, hasChild: category.SubCategories is not null && category.SubCategories.Any()));
        var result = new Response<List<CategoryHasChildResponse>>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Categories found",
            Succeeded = true,
            Data = hasChildCategories.Select(c => new CategoryHasChildResponse(c.c.Id, c.c.Name, c.c.ParentId, _fileSystemService.DownloadFileResponse(c.c.File.FileName), c.hasChild, c.c.IsActive)).ToList()
        };
        return NewResult(result);
    }
    [HttpGet("GetAvailableTechnicians/{categoryId?}")]
    public IActionResult GetAvailableTechnicians([FromRoute] int? categoryId = null)
    {

        var categories = _unitOfWork.GenericRepository<Category>().GetAll(c => c.ParentId == categoryId, include: c => c.Include(s => s.SubCategories));
        if (categories is null)
            return NotFound("Categories not found");
        var hasChildCategories = categories.Select(category => (c: category, hasChild: category.SubCategories is not null && category.SubCategories.Any()));
        var result = new Response<List<CategoryHasChildResponse>>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Categories found",
            Succeeded = true,
            Data = hasChildCategories.Select(c => new CategoryHasChildResponse(c.c.Id, c.c.Name, c.c.ParentId, _fileSystemService.DownloadFileResponse(c.c.File.FileName), c.hasChild, c.c.IsActive)).ToList()
        };
        return NewResult(result);
    }
    [HttpGet("GetServices/{categoryId?}")]
    public IActionResult GetServices([FromRoute] int id)
    {

        var categories = _unitOfWork.GenericRepository<Category>().GetAll(c => c.ParentId == id, include: c => c.Include(s => s.SubCategories));
        if (categories is null)
            return NotFound("Categories not found");
        var hasChildCategories = categories.Select(category => (c: category, hasChild: category.SubCategories is not null && category.SubCategories.Any()));
        var result = new Response<List<CategoryHasChildResponse>>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Categories found",
            Succeeded = true,
            Data = hasChildCategories.Select(c => new CategoryHasChildResponse(c.c.Id, c.c.Name, c.c.ParentId, _fileSystemService.DownloadFileResponse(c.c.File.FileName), c.hasChild, c.c.IsActive)).ToList()
        };
        return NewResult(result);
    }

}
