using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebJerseyGoal.Constants;
using Domain;
using Domain.Entitties;
using Core.Interfaces;
using Core.Models.Category;
using Core.Services;

namespace WebJerseyGoal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService categoryService) : ControllerBase
    {
        [HttpGet]
        //[Authorize(Roles = $"{Roles.Admin}")]
        public async Task<IActionResult> List()
        {
            var model = await categoryService.List();

            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            var model = await categoryService.GetItemById(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }



        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CategoryCreateViewModel model)
        {
            var  category = await categoryService.Create(model);
            return Ok(category);
        }



        [HttpPut] //Якщо є метод Put - це значить змінна даних
        public async Task<IActionResult> Edit([FromForm] CategoryEditViewModel model)
        {
           var category = await categoryService.Edit(model);
           return Ok();
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await categoryService.Delete(id);
            return Ok();
        }


    }
}
