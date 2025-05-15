namespace WebJerseyGoal.Models.Category
{
    public class CategoryCreateViewModel
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public IFormFile Image { get; set; }
    }
}
