using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebJerseyGoal.DataBase;
using WebJerseyGoal.DataBase.Entitties;
using WebJerseyGoal.Interfaces;
using WebJerseyGoal.Models.Category;
using WebJerseyGoal.Services;

namespace WebJerseyGoal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(AppDbJerseyGoalContext jerseyContext,IMapper mapper,IImageService imageService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var model = await mapper.ProjectTo<CategoryItemViewModel>(jerseyContext.Categories).ToListAsync();

            return Ok(model);
        }



        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var exist = await jerseyContext.Categories.SingleOrDefaultAsync(x => x.Name == model.Name);

            if (exist != null)
            {
                return BadRequest($"{model.Name} already exists");
            }


            var entity = mapper.Map<CategoryEntity>(model);
            entity.Image = await imageService.SaveImageAsync(model.Image);

            await jerseyContext.Categories.AddAsync(entity);
            await jerseyContext.SaveChangesAsync();

            //var result = mapper.Map<CategoryItemViewModel>(entity); 

            //return CreatedAtAction(nameof(List), new { id = entity.Id }, result);
            return Ok(entity);
        }




    }
}
