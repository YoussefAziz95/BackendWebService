using Api.Base;
using Application.Contracts.Persistence;
using Application.Contracts.Services;
using Application.Features;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v2;


[ApiController]
[AllowAnonymous]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ProductController : AppControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileSystemService _fileSystemService;

    public ProductController(IUnitOfWork unitOfWork,
        IFileSystemService fileSystemService)
    {
        _unitOfWork = unitOfWork;
        _fileSystemService = fileSystemService;
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
    {
        //var product = new Product
        //{
        //    Number = request.Number,
        //    Name = request.Name,
        //    Description = request.Description,
        //    Code = request.Code,
        //    PartNumber = request.PartNumber,
        //    Manufacturer = request.Manufacturer,
        //    CategoryId = request.CategoryId
        //};
        //if (!_unitOfWork.GenericRepository<FileLog>().Exists(f => f.Id == request.FileId))
        //    return NotFound("File not found");
        //product.File = _unitOfWork.GenericRepository<FileLog>().Get(f => f.Id == request.FileId);
        //product.FileId = request.FileId;
        //_unitOfWork.GenericRepository<Product>().Add(product);
        //var result = _unitOfWork.Save();

        //return Ok(product.Id);

        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct([FromRoute] int id)
    {
        //var product = await _unitOfWork.GenericRepository<Product>().GetByIdAsync(id);
        //if (product == null)
        //    return NotFound("Product not found");

        //var response = new Response<ProductResponse>()
        //{
        //    StatusCode = ApiResultStatusCode.Success,
        //    Message = "Product found",
        //    Succeeded = true,
        //    Data = new ProductResponse(product.Id, product.Number, product.Name, product.Description, _fileSystemService.DownloadFileResponse(product.File.FileName), product.Code, product.PartNumber, product.Manufacturer, product.CategoryId, product.IsActive)
        //};

        //return NewResult(response);

        throw new NotImplementedException();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest request)
    {
        //var product = await _unitOfWork.GenericRepository<Product>().GetByIdAsync(request.Id);
        //if (product == null)
        //    return NotFound("Product not found");

        //product.Number = request.Number;
        //product.Name = request.Name;
        //product.Description = request.Description;
        //if ((product.FileId ?? 0) != request.FileId)
        //{
        //    if (product.FileId as int? != null)
        //    {
        //        var fileLog = _unitOfWork.GenericRepository<FileLog>().Get(f => f.Id == request.FileId, disableTracking: true);
        //        _fileSystemService.DeleteFile(fileLog.FileName);
        //    }
        //}
        //if (!_unitOfWork.GenericRepository<FileLog>().Exists(f => f.Id == request.FileId))
        //    return NotFound("Product not found");
        //product.File = _unitOfWork.GenericRepository<FileLog>().Get(f => f.Id == request.FileId);
        //product.FileId = request.FileId;
        //product.Code = request.Code;
        //product.PartNumber = request.PartNumber;
        //product.Manufacturer = request.Manufacturer;
        //product.CategoryId = request.CategoryId;

        //_unitOfWork.GenericRepository<Product>().Update(product);
        //var result = _unitOfWork.Save();

        //var response = new Response<ProductResponse>()
        //{
        //    StatusCode = ApiResultStatusCode.Success,
        //    Message = "Product updated successfully",
        //    Succeeded = true,
        //    Data = new ProductResponse(product.Id, product.Number, product.Name, product.Description, _fileSystemService.DownloadFileResponse(product.File.FileName), product.Code, product.PartNumber, product.Manufacturer, product.CategoryId, product.IsActive)
        //};

        //return NewResult(response);

        throw new NotImplementedException();
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        //var products = _unitOfWork.GenericRepository<Product>().GetAll(include: c => c.Include(u => u.File));
        //if (products == null || !products.Any())
        //    return NotFound("Products not found");

        //var result = new Response<List<ProductResponse>>()
        //{
        //    StatusCode = ApiResultStatusCode.Success,
        //    Message = "Products found",
        //    Succeeded = true,
        //    Data = products.Select(p =>
        //        new ProductResponse(p.Id, p.Number, p.Name, p.Description, _fileSystemService.DownloadFileResponse(p.File.FileName), p.Code, p.PartNumber, p.Manufacturer, p.CategoryId, p.IsActive)).ToList()
        //};

        //return NewResult(result);

        throw new NotImplementedException();
    }
}
