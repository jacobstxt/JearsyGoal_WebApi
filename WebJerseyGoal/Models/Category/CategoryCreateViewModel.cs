﻿namespace WebJerseyGoal.Models.Category
{
    public class CategoryCreateViewModel
    {
        public string Name { get; set; } = String.Empty;
        public string Slug { get; set; } = String.Empty;
        public IFormFile? Image { get; set; } = null;
    }
}
