using System;
using System.Collections.Generic;

#nullable disable

namespace Recipes.Models
{
    public partial class Ingredient
    {
        public int Id { get; set; }
        public decimal? Kolicina { get; set; }
        public int? RecipesId { get; set; }
        public int? FkNaziv { get; set; }

        public virtual Namirnice FkNazivNavigation { get; set; }
        public virtual Recipe Recipes { get; set; }
    }
}
