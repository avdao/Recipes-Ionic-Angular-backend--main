using System;
using System.Collections.Generic;

#nullable disable

namespace Recipes.Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            Ingredients = new HashSet<Ingredient>();
        }

        public int RecipesId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int? KategorijaId { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
