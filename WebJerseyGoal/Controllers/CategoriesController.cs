using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebJerseyGoal.DataBase;
using WebJerseyGoal.Models.Category;

namespace WebJerseyGoal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(AppDbJerseyGoalContext jerseyContext,IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var model = await mapper.ProjectTo<CategoryItemViewModel>(jerseyContext.Categories).ToListAsync();

            return Ok(model);
        }
    }
}
