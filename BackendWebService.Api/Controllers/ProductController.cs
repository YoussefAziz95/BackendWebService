using Api.Base;
using Application.Contracts.Persistences;
using Application.DTOs;
using Application.DTOs.Common;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class ProductController : AppControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
    {
        var product = new Product
        {
            Number = request.Number,
            Name = request.Name,
            Description = request.Description,
            Image = request.Image,
            Code = request.Code,
            PartNumber = request.PartNumber,
            Manufacturer = request.Manufacturer,
            CategoryId = request.CategoryId
        };

        _unitOfWork.GenericRepository<Product>().Add(product);
        var result = _unitOfWork.Save();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct([FromRoute] int id)
    {
        var product = await _unitOfWork.GenericRepository<Product>().GetByIdAsync(id);
        if (product == null)
            return NotFound("Product not found");

        var response = new Response<ProductResponse>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Product found",
            Data = new ProductResponse(product.Id, product.Number, product.Name, product.Description, product.Image, product.Code, product.PartNumber, product.Manufacturer, product.CategoryId, product.IsActive)
        };

        return NewResult(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest request)
    {
        var product = await _unitOfWork.GenericRepository<Product>().GetByIdAsync(request.Id);
        if (product == null)
            return NotFound("Product not found");

        product.Number = request.Number;
        product.Name = request.Name;
        product.Description = request.Description;
        product.Image = request.Image;
        product.Code = request.Code;
        product.PartNumber = request.PartNumber;
        product.Manufacturer = request.Manufacturer;
        product.CategoryId = request.CategoryId;

        _unitOfWork.GenericRepository<Product>().Update(product);
        var result = _unitOfWork.Save();

        var response = new Response<ProductResponse>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Product updated successfully",
            Data = new ProductResponse(product.Id, product.Number, product.Name, product.Description, product.Image, product.Code, product.PartNumber, product.Manufacturer, product.CategoryId, product.IsActive)
        };

        return NewResult(response);
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var products = _unitOfWork.GenericRepository<Product>().GetAll();
        if (products == null || !products.Any())
            return NotFound("Products not found");

        var result = new Response<List<ProductResponse>>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Products found",
            Data = products.Select(p =>
                new ProductResponse(p.Id, p.Number, p.Name, p.Description, p.Image, p.Code, p.PartNumber, p.Manufacturer, p.CategoryId, p.IsActive)).ToList()
        };

        return NewResult(result);
    }
}
