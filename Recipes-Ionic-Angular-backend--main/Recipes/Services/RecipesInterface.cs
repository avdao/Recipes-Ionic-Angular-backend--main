using Microsoft.AspNetCore.Mvc;
using Recipes.Models;
using System.Collections.Generic;

namespace Recipes.Services
{
    public interface RecipesInterface
    {
        public string returnV(string data);

        public List<Recipe> get(string search="");
   
        public Recipe getById(int id);
        public void DeleteRecipe(int id);
    

        public void post(Recipe recipe);
        public void edit(Recipe recipe);
    }
}
