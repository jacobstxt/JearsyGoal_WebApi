﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core.Models.Product.Ingredient
{
    public class CreateIngredientModel
    {
        public string Name { get; set; } = string.Empty;
        public IFormFile? ImageFile { get; set; }
    }
}
