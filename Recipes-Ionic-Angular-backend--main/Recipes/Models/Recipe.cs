using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Recipes.Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            Ingredients = new HashSet<Ingredient>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecipesId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int? KategorijaId { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
