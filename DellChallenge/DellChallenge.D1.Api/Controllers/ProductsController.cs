using System;
using DellChallenge.D1.Api.Dal;
using DellChallenge.D1.Api.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace DellChallenge.D1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        [EnableCors("AllowReactCors")]
        public ActionResult<IEnumerable<ProductDto>> Get()
        {
            return Ok(_productsService.GetAll());
        }

        [HttpGet("{id}")]
        [EnableCors("AllowReactCors")]
        public ActionResult<string> Get(string id)
        {
            ProductDto product = _productsService.GetAll().FirstOrDefault(p => p.Id == id);
            return Ok(product);
        }

        [HttpPost]
        [EnableCors("AllowReactCors")]
        public ActionResult<ProductDto> Post([FromBody] NewProductDto newProduct)
        {
            var addedProduct = _productsService.Add(newProduct);
            return Ok(addedProduct);
        }

        [HttpDelete("{id}")]
        [EnableCors("AllowReactCors")]
        public void Delete(string id)
        {
            _productsService.Delete(id);
        }

        [HttpPut]
        [EnableCors("AllowReactCors")]
        public ActionResult<string> Put([FromBody] Product product)
        {

            var error = _productsService.Update(product);

            if (error.Length > 0)
            {
                return BadRequest(error);
            }

            return Ok();

        }

        [HttpOptions()]
        [EnableCors("AllowReactCors")]
        public StatusCodeResult Options()
        {
            return Ok();
        }
    }
}
