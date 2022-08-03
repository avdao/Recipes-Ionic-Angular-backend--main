using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Recipes.Models
{
    public partial class Ingredient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal? Kolicina { get; set; }
        public string Naziv { get; set; }
        public int? RecipesId { get; set; }

        public virtual Recipe Recipes { get; set; }

    }
}
