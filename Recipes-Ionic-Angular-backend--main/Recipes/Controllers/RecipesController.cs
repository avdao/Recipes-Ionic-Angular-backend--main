using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Recipes.Models;
using Recipes.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recipes.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
        
    {

        private readonly RecipesInterface recipesService;
   

        public RecipesController(RecipesInterface recipesInterface)
        {
            recipesService=recipesInterface;
        }

        /* [HttpGet]
         public string get()
         {
             return recipesService.returnV("Hello Avdo");
         }
        */
        [HttpGet]
  
        public List<Recipe> get(string search="")
        {
            return  recipesService.get();

        }
        [HttpGet("{id}")]
        public Recipe getByid(int id)
        {
          
            return recipesService.getById(id);
        }
     
        [HttpDelete("{id}")]
        public void deleteRecipe(int id)
        {
            recipesService.DeleteRecipe(id);
        }

        [HttpPost]

        public void postData(Recipe recipe)
        {
            recipesService.post(recipe);
        }

        [HttpPut("{id}")]
        public void edit(Recipe recipe)
        {
            recipesService.edit(recipe);
        }



    }
}
