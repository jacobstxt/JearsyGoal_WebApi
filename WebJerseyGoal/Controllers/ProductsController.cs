﻿using Core.Interfaces;
using Core.Models.Product;
using Core.Models.Product.Ingredient;
using Microsoft.AspNetCore.Mvc;

namespace WebJerseyGoal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var model = await productService.List();

            return Ok(model);
        }
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var model = await productService.GetById(id);

            return Ok(model);
        }
        [HttpGet("slug/{slug}")]
        public async Task<IActionResult> GetBySlug(string slug)
        {
            var model = await productService.GetBySlug(slug);

            return Ok(model);
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] ProductCreateModel model)
        {
            var salo = Request.Form;
            if (model.ImageFiles == null)
                return BadRequest("Image files are empty!");
            if (model.IngredientIds == null)
                return BadRequest("Product ingredients are empty!");
            var entity = await productService.Create(model);
            if (entity != null)
                return Ok(model);
            else return BadRequest("Error create product!");
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Edit([FromForm] ProductEditModel model)
        {
            var salo = Request.Form;
            if (model.ImageFiles == null)
                return BadRequest("Image files are empty!");
            if (model.IngredientIds == null)
                return BadRequest("Product ingredients are empty!");
            var entity = await productService.Edit(model);
            if (entity != null)
                return Ok(model);
            else return BadRequest("Error edit product!");
        }


        [HttpGet("sizes")]
        public async Task<IActionResult> GetSizes()
        {
            var sizes = await productService.GetSizesAsync();

            return Ok(sizes);
        }

        [HttpGet("ingredients")]
        public async Task<IActionResult> GetIngredients()
        {
            var ingredients = await productService.GetIngredientsAsync();

            return Ok(ingredients);
        }


        [HttpPost("ingredients")]
        public async Task<IActionResult> UploadIngredient([FromForm] CreateIngredientModel model)
        {
            if (model.ImageFile == null)
                return BadRequest("Image file is empty!");
            var ingredient = await productService.UploadIngredient(model);
            if (ingredient != null)
                return Ok(ingredient);
            else return BadRequest("Error upload ingredient!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await productService.Delete(id);
            return Ok(new { message = "Product deleted successfully!" });
        }
    }

}
