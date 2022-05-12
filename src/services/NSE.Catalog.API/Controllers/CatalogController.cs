﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSE.Catalog.API.Models;
using NSE.WebAPI.Core.Controllers;
using NSE.WebAPI.Core.Identity;

namespace NSE.Catalog.API.Controllers
{
    [Route("api/catalog")]
    [Authorize]
    public class CatalogController : MainController
    {
        private readonly IProductRepository _productRepository;

        public CatalogController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [AllowAnonymous]
        [HttpGet("products")]        
        public async Task<IEnumerable<Product>> Index()
        {
            return await _productRepository.GetAll();
        }

        [ClaimsAuthorize("catalog", "read")]
        [HttpGet("products/{id}")]
        public async Task<Product> Details(Guid id)
        {
            return await _productRepository.GetById(id);
        }

        [HttpGet("products/list/{ids}")]
        public async Task<IEnumerable<Product>> GetManyById(string ids)
        {
            return await _productRepository.GetProductsById(ids);
        }
    }
}
