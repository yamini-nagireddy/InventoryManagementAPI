using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using InventoryAPI.Domain.Services;
using InventoryAPI.Resources;
using InventoryAPI.Domain.Models;


namespace InventoryAPI.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ProductsController: Controller
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductsController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ProductResource>> ListAsync()
    {
        var products = await _productService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
        return resources;
    }
}