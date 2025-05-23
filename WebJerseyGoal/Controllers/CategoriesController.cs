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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            var model = await mapper
                .ProjectTo<CategoryItemViewModel>(jerseyContext.Categories.Where(x => x.Id == id))
                .SingleOrDefaultAsync();
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }



        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CategoryCreateViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            var exist = await jerseyContext.Categories.Where(x => x.Name == model.Name).SingleOrDefaultAsync();
           

            if (exist != null)
            {
                return BadRequest($"{model.Name} already exists");
            }


            var entity = mapper.Map<CategoryEntity>(model);
            entity.Image = await imageService.SaveImageAsync(model.Image!);

            await jerseyContext.Categories.AddAsync(entity);
            await jerseyContext.SaveChangesAsync();

            //var result = mapper.Map<CategoryItemViewModel>(entity); 

            //return CreatedAtAction(nameof(List), new { id = entity.Id }, result);
            return Ok(entity);
        }



        [HttpPut] //Якщо є метод Put - це значить змінна даних
        public async Task<IActionResult> Edit([FromForm] CategoryEditViewModel model)
        {
            var existing = await jerseyContext.Categories.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (existing == null)
            {
                return NotFound();
            }

            existing = mapper.Map(model, existing);

            if (model.Image != null)
            {
                await imageService.DeleteImageAsync(existing.Image);
                existing.Image = await imageService.SaveImageAsync(model.Image);
            }
            await jerseyContext.SaveChangesAsync();

            return Ok();
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await jerseyContext.Categories.SingleOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(category.Image))
            {
                await imageService.DeleteImageAsync(category.Image);
            }

            jerseyContext.Categories.Remove(category);
            await jerseyContext.SaveChangesAsync();

            return Ok();
        }


    }
}
