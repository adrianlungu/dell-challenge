using DellChallenge.D2.Web.Models;
using DellChallenge.D2.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DellChallenge.D2.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _productService.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(NewProductModel newProduct)
        {
            
            if (!ModelState.IsValid)
            {
                return View();
            }

            _productService.Add(newProduct);

            return RedirectToAction("Index");

        }

        [HttpPut]
        public IActionResult Update(ProductModel product)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            _productService.Update(product);

            return RedirectToAction("Index");

        }
    }
}