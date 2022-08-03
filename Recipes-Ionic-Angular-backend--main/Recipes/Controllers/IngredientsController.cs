using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipes.Models;
using Recipes.Services;
using System.Collections.Generic;

namespace Recipes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {

        private readonly  IngredientsInterface recipesService;


        public IngredientsController(IngredientsInterface recipesInterface)
        {
            recipesService = recipesInterface;
        }

        [HttpGet]
        public List<Ingredient> get()
        {
            return recipesService.getAllCategory();

        }
        [HttpDelete("{id}")]
        public void deleteByid(int id)
        {
            recipesService.deleteById(id);
        }
        [HttpGet("{id}")]
        public Ingredient getByid(int id)
        {
            
            return recipesService.getById(id);

        }

        [HttpPost]
        public void postData(Ingredient c)
        {
            recipesService.post(c);
        }

        [HttpPut("{id}")]
        public void edit(Ingredient c)
        {
            recipesService.edit(c);
        }



    }
}
